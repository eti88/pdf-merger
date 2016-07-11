using iTextSharp.text;
using iTextSharp.text.pdf;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfMerger
{
    // classe per la gestione semplificata dei dati dei file
    // per consentire la ricerca di corrispondenze tra loro.

    public partial class Form1 : Form
    {
        public List<string>[] arrayListZ = new List<string>[100000];	// limit len list
        public List<Cliente> listaClienti = new List<Cliente>();
        public List<Cliente> tmpList;
        public List<string> tmpArray = new List<string>();
        
        
        public Logger myLog = LogManager.GetLogger("Main");

        // Main del programma
        public Form1()
        {
            InitializeComponent();
        }

        private void btSfoglia_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathBox.Text = folderDlg.SelectedPath;                           //assegna al textBox il valore del path
                //Application.Restart();                                              //ricarica l'applicazione
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void butContinua_Click(object sender, EventArgs e)
        { 
            if (checkMergeLists.Checked == false) {
                
                string folder = txtPathBox.Text;
                string outFolder = txtOutputPath.Text;
                label1.Text = "preparazione...";          
                ReadFileToList(folder);          
                calculatePbar();
                //Resetto la progress bar dopo il riempimento della lista
                label1.Text = "Unione PDF...";
                Directory.SetCurrentDirectory(folder);
                for (int k = 0; k < arrayListZ.Length; k++ )
                {
                    if ((arrayListZ[k] != null)) { 
                        //creo il nome del file nel quale unire i pdf
                        string outNameFile = arrayListZ[k].ElementAt(0) + @".pdf";
                        outNameFile = outNameFile.Replace("/", "_");
                        string outPtFile = Path.Combine(outFolder, outNameFile);
                        arrayListZ[k].RemoveAt(0);
                        MergeMultiplePDFIntoSinglePDF(arrayListZ[k], outPtFile);
                        progressBar.PerformStep();
                    }
                }
                //Reset
                label1.Text = "Fine!";
                arrayListZ = new List<string>[100000];
                MessageBox.Show("Done");
           
            }
            else
            {
                // Se selezionata la checkbox procedo con l'unione dei pdf presenti in due liste differenti
                string folder1 = txtPathBox.Text;
                string folder2 = txtPathBox2.Text;
                string folder3 = txtPathBox3.Text;
                string folder4 = txtPathBox4.Text;
                string outFolder = txtOutputPath.Text;
                label1.Text = "preparazione...";
               
                //passo alla lista i parametri per creare i clienti (conto e path)
                if ((folder1 != null) && (folder1.Length > 0)) { 
                    ReadToList(folder1, listaClienti);
                }
                if ((folder2 != null) && (folder2.Length > 0)) {
                    ReadToList(folder2, listaClienti);
                }
                if ((folder3 != null) && (folder3.Length > 0))
                {
                    ReadToList(folder3, listaClienti);
                }
                if ((folder4 != null) && (folder4.Length > 0))
                {
                    ReadToList(folder4, listaClienti);
                }

                calcProBarClienti(listaClienti);

                int f = 0;
                string test;
                string fileOut = "";
                string pathFileOut = "";
                //nell'altro metodo per il corretto svolgimento della procedura bisognava entrare nella directory dalla quale si preleva il file db
                //Directory.SetCurrentDirectory(folder);
                //controllare se davvero è quello il punto di partenza corretto oppure si può procedere con i path relativi

                for (int p = 0; p < listaClienti.Count; p++)
                {
                    f = 0;
                    test = listaClienti[p].conto;
                    tmpList = searchCode(test, listaClienti);
                    
                    
                    tmpList.ForEach(delegate(Cliente c)
                    {
                        //Console.WriteLine(String.Format("{0} {1}", c.conto, c.path));
                        tmpArray.Add(c.conto.ToString());
                        fileOut = c.conto + @".pdf";
                        fileOut = fileOut.Replace("/", "_");
                    });
                    
                    pathFileOut = Path.Combine(outFolder, fileOut);
                    MergeMultiplePDFIntoSinglePDF(tmpArray, pathFileOut);
                    progressBar.PerformStep();

                    listaClienti.RemoveAll(x => x.conto == test);
                }
                //Reset
                label1.Text = "Fine!";
                listaClienti.Clear();
                tmpList.Clear();
                tmpArray.Clear();
                MessageBox.Show("Done");
            }
        }

        public List<Cliente> searchCode(string contoz, List<Cliente> lista) {
            List<Cliente> lstOut = new List<Cliente>();
            var g = lista.FindAll(x => x.conto == contoz);
            g.ForEach(delegate(Cliente c)
            {
                lstOut.Add(new Cliente(c.conto, c.path));
            });

            return lstOut;
        }

        //Calcola lunghezza progress bar
        public void calculatePbar() {
            int maxLenBar = 0;
            for (int cou = 0; cou < arrayListZ.Length; cou++)
            {
                if (arrayListZ[cou] != null)
                {
                    maxLenBar++;
                }
                else
                {
                    break;
                }

            }
            progressBar.Maximum = maxLenBar;
        }

        public void calcProBarClienti(List<Cliente> abcList)
        {
            int maxLenBar = 0;
            for (int cou = 0; cou < abcList.Count; cou++)
            {
                if (abcList[cou] != null){
                    maxLenBar++;
                }else{
                    break;
                }
            }
            progressBar.Maximum = maxLenBar;
        }

        private void ReadToList(string directory, List<Cliente> listaDest) { 
            string line = "";
            // Recuper il file txt dalla directory
            string[] txtFile = Directory.GetFiles(directory, "*.txt");
            // Combino il file con la directory per avere il percorso completo
            string fullPathF = Path.Combine(directory, txtFile[0]);
            string codice;
            string path;

            try{
                // Leggo le righe nel file
                using (StreamReader st = new StreamReader(fullPathF)){                   
                    while ((line = st.ReadLine()) != null){
                        codice = line.Split(';')[1];
                        path = line.Split(';')[3];
                        listaDest.Add(new Cliente(codice, path));
                    }
                    st.Close();
                }          
            }catch (Exception err)
            {
                myLog.Error("==== ERROR ====");
                myLog.Error("linea: " + line);
                myLog.Error(err.ToString());  
            }
        }

        // metodo per la creazione dell'array di lista con singolo file
        private void ReadFileToList(string folder)
        {
            string line = "";
            try
            {
                string[] txtfile = Directory.GetFiles(folder, "*.txt");
                string fullPathTxtFile = Path.Combine(folder, txtfile[0]);            

                //implementare una scelta automatica del file con estensione .txt nella cartella
                Boolean cl = true;
                Boolean cx = true;

                using (StreamReader sr = new StreamReader(fullPathTxtFile.ToString()))
                {
                    string contoCorrente;
                    string nomePdfDaUnire;
                    int j=0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        contoCorrente = line.Split(';')[1];  //prende solo la parte del conto corrente senza i ;
                        nomePdfDaUnire = line.Split(';')[3]; //prende solo il nome del fil
                        cx = true;
                        if(cl == true){
                            //prima riga analizzata
                            arrayListZ[j] = new List<string>();
                            arrayListZ[j].Add(contoCorrente);
                            arrayListZ[j].Add(nomePdfDaUnire);
                            cl = false;
                            ++j;
                        }else{
                            for (int z = 0; z < arrayListZ.Length; z++)
                            {
                                if (cx == false) { break; }
                                if ((arrayListZ[z] != null) && (arrayListZ[z].ElementAt(0) == contoCorrente))
                                { 
                                    arrayListZ[z].Add(nomePdfDaUnire);
                                    cx = false;
                                }
                                
                                if ((arrayListZ[z] == null) && (cx == true))
                                {
                                    arrayListZ[j] = new List<string>();
                                    arrayListZ[j].Add(contoCorrente);
                                    arrayListZ[j].Add(nomePdfDaUnire);
                                    ++j;
                                    cl = false;
                                    cx = false;
                                }

                            }
                 
                        }
                    }
                    sr.Close();
                }
            }
            catch (Exception err)
            {
                myLog.Error("==== ERROR ====");
                myLog.Error("linea: " + line);
                myLog.Error(err.ToString());              
            }

        }

        // Funzione merge multi pdf (singolo file input)
        private void MergeMultiplePDFIntoSinglePDF(List<string> pdfFiles, string outputFilePath)
        {
            string strack = string.Join(",", pdfFiles.ToArray());

            using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream))
            {
                try { 
                doc.Open();

                PdfReader reader = null;
                PdfImportedPage page = null;

                //fixed typo
                pdfFiles.ForEach(file =>
                {
                    reader = new PdfReader(file);

                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        page = pdf.GetImportedPage(reader, i + 1);
                        pdf.AddPage(page);
                    }                   
                    pdf.FreeReader(reader);
                    reader.Close();
                });
                }
                catch (Exception ex)
                {
                    myLog.Error("==== ERROR ====");
                    myLog.Error("Informazioni addizionali:");
                    myLog.Error("L'errore dovrebbe essere presente in uno dei seguenti File: ");
                    myLog.Error(strack);
                    myLog.Error(ex.ToString());                    
                }
            }
            
        }
        /*
        private void MergeMultiplePDFIntoSinglePDFClienti(List<Cliente> pdfFiles, string outputFilePath)
        {

            List<string> tmp = new List<string>();
            for (int g = 0; g < pdfFiles.Count; g++) {
                tmp.Add(pdfFiles[g].conto + "," + pdfFiles[g].path);
            }

            string strack = string.Join(",", pdfFiles);

            using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
            using (Document doc = new Document())
            using (PdfCopy pdf = new PdfCopy(doc, stream))
            {
                try
                {
                    doc.Open();

                    PdfReader reader = null;
                    PdfImportedPage page = null;

                    //fixed typo
                    pdfFiles.ForEach(file =>
                    {
                        reader = new PdfReader(file);

                        for (int i = 0; i < reader.NumberOfPages; i++)
                        {
                            page = pdf.GetImportedPage(reader, i + 1);
                            pdf.AddPage(page);
                        }
                        pdf.FreeReader(reader);
                        reader.Close();
                    });
                }
                catch (Exception ex)
                {
                    myLog.Error("==== ERROR ====");
                    myLog.Error("Informazioni addizionali:");
                    myLog.Error("L'errore dovrebbe essere presente in uno dei seguenti File: ");
                    myLog.Error(strack);
                    myLog.Error(ex.ToString());
                }
            }

        }
        */
        private void btSofoflia2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputPath.Text = folderDlg.SelectedPath;                           //assegna al textBox il valore del path                                             //ricarica l'applicazione
            }
        }

        private void checkMergeLists_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMergeLists.Checked)
            {
                txtPathBox2.Enabled = true;
                btSofoflia3.Enabled = true;
                txtPathBox3.Enabled = true;
                btSofoflia4.Enabled = true;
                txtPathBox4.Enabled = true;
                btSofoflia5.Enabled = true;

            }
            else {
                txtPathBox2.Enabled = false;
                btSofoflia3.Enabled = false;
                txtPathBox3.Enabled = false;
                btSofoflia4.Enabled = false;
                txtPathBox4.Enabled = false;
                btSofoflia5.Enabled = false;
            }

            


        }

        private void btSofoflia3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathBox2.Text = folderDlg.SelectedPath;
            }
        }

        private void btSofoflia4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathBox3.Text = folderDlg.SelectedPath;
            }
        }

        private void btSofoflia5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;

            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPathBox4.Text = folderDlg.SelectedPath;
            }
        }

        

    }

    public class Cliente
    {
        public string conto;
        public string path;

        public Cliente(string conto, string path)
        {
            this.conto = conto;
            this.path = path;
        }
    }

}
