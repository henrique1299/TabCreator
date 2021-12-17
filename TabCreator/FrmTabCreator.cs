using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabCreator
{
    public partial class FrmTabCreator : Form
    {
        public FrmTabCreator()
        {
            InitializeComponent();
        }

        int aaa;
        public bool saved = false;
        public string caminho;
        string caminho2;
        string caminhoBK;
        public string[] corda1;
        public string[] corda2;
        public string[] corda3;
        public string[] corda4;
        public string[] corda5;
        public string[] corda6;

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabControl.SelectedTab != null) &&
                (tabControl.SelectedTab.Tag != null))
                (tabControl.SelectedTab.Tag as Form).Select();
        }

        private void FrmTabCreator_Load(object sender, EventArgs e)
        {
            aaa = Application.OpenForms.OfType<FrmTabs>().Count();
            FrmSplashSreen splash = new FrmSplashSreen();
            splash.ShowDialog();
            saved = true;
            btnNewProject.PerformClick();
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void FrmTabCreator_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabControl.Visible = false;
            // If no any child form, hide tabControl 
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                // Child form always maximized 

                // If child form is new and no has tabPage, 
                // create new tabPage 
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                        new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabControl.Visible) tabControl.Visible = true;
            }
        }

        private void AdicionaForm()
        {
            if (this.ActiveMdiChild == null)
                tabControl.Visible = false;
            // If no any child form, hide tabControl 
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                // Child form always maximized 

                // If child form is new and no has tabPage, 
                // create new tabPage 
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                        new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabControl.Visible) tabControl.Visible = true;
            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                DialogResult dialogResult = MessageBox.Show("Deseja salvar antes de fechar?", "Salvamento", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    btnSave.PerformClick();
                }
            }
            saved = false;
            aaa++;

            if (tabControl.TabCount != 0)
                tabControl.TabPages.Remove(tabControl.SelectedTab);

            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                {
                    Application.OpenForms[intIndex].Close();
                }
            }

            FrmTabs form = new FrmTabs("");
            form.Text = "New_Project_" + aaa;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.MdiParent = this;
                form.Show();
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                // If child form is new and no has tabPage, 
                // create new tabPage 
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child 
                    // form caption 
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed +=
                    new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabControl.Visible) tabControl.Visible = true;

            // Child form always maximized 
            
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {
                DialogResult dialogResult = MessageBox.Show("Deseja salvar antes de fechar?", "Salvamento", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    btnSave.PerformClick();
                }
            }
            saved = true;

            for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                {
                    Application.OpenForms[intIndex].Close();
                }
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tab | *.tab|Partitura | *.part";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                caminho = fileName;
                caminho2 = caminho.Replace(".tab", ".temp");
                caminhoBK = caminho.Replace(".tab", ".txt");

                var arqInfo = File.ReadAllLines(fileName);
                //foreach (string a in arqInfo)
                //{
                //    File.AppendAllText(diretorio + fileName + ".txt", a + "\r\n");
                //}
                if (tabControl.TabCount != 0)
                    tabControl.TabPages.Remove(tabControl.SelectedTab);

                FrmTabs form = new FrmTabs(fileName);
                form.Text = Path.GetFileName(fileName);
                form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                form.MdiParent = this;
                form.Show();

                tabControl.TabPages.Remove(tabControl.SelectedTab);
                TabPage tp = new TabPage(Path.GetFileName(fileName));
                tabControl.Controls.Add(tp);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
            if (aa != null)
            {
                NotasTab tab = new NotasTab();
                corda1 = aa.C1();
                corda2 = aa.C2();
                corda3 = aa.C3();
                corda4 = aa.C4();
                corda5 = aa.C5();
                corda6 = aa.C6();

                if (Application.OpenForms.Count > 1)
                {
                    if (saved == false)
                    {
                        var frmTabs = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Tab | *.tab|Partitura | *.part";
                        sfd.Title = "Save Project";
                        sfd.FileName = frmTabs.Text;
                        string texto = tab.returnNotas();

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            #region SalvaNovoArq
                            if (sfd.FileName != "" && texto != "")
                            {
                                if (File.Exists(caminhoBK))
                                    File.Delete(caminhoBK);

                                caminho = sfd.FileName;
                                caminho2 = caminho.Replace(".tab", ".temp");
                                caminhoBK = caminho.Replace(".tab", ".txt");

                                File.AppendAllText(caminho, "");
                                try
                                {
                                    File.Move(caminho, caminhoBK);
                                }
                                catch { MessageBox.Show("Erro!", "Falha ao salvar!"); }

                                try
                                {
                                    if (File.Exists(caminho))
                                        File.Delete(caminho);
                                }
                                catch { }
                                try
                                {
                                    for (int i = 0; i < corda2.Length; i++)
                                    {
                                        File.AppendAllText(caminho, corda1[i]);
                                    }
                                    File.AppendAllText(caminho, "\r\n");

                                    for (int i = 0; i < corda2.Length; i++)
                                    {
                                        File.AppendAllText(caminho, corda2[i]);
                                    }
                                    File.AppendAllText(caminho, "\r\n");

                                    for (int i = 0; i < corda2.Length; i++)
                                    {
                                        File.AppendAllText(caminho, corda3[i]);
                                    }
                                    File.AppendAllText(caminho, "\r\n");

                                    for (int i = 0; i < corda2.Length; i++)
                                    {
                                        File.AppendAllText(caminho, corda4[i]);
                                    }
                                    File.AppendAllText(caminho, "\r\n");

                                    for (int i = 0; i < corda2.Length; i++)
                                    {
                                        File.AppendAllText(caminho, corda5[i]);
                                    }
                                    File.AppendAllText(caminho, "\r\n");

                                    for (int i = 0; i < corda2.Length; i++)
                                    {
                                        File.AppendAllText(caminho, corda6[i]);
                                    }
                                    File.AppendAllText(caminho, "\r\n");

                                }
                                catch
                                {
                                    MessageBox.Show("ERRO", "Falha ao salvar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (File.Exists(caminho))
                                        File.Delete(caminho);

                                    File.Move(caminhoBK, caminho);
                                    File.Delete(caminhoBK);
                                }
                                finally
                                {
                                    File.Delete(caminhoBK);
                                }

                                string aux = Path.GetFileName(caminho);

                                string nomeFrm = aux;

                                tabControl.TabPages.Remove(tabControl.SelectedTab);

                                TabPage tp = new TabPage(nomeFrm);
                                tabControl.Controls.Add(tp);
                                saved = true;
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        #region SalvaEmArqExistente
                        try
                        {
                            if (File.Exists(caminho))
                                File.Delete(caminho);
                        }
                        catch
                        {
                            MessageBox.Show("Erro!", "Falha ao salvar!");
                        }

                        string texto = tab.returnNotas();

                        File.AppendAllText(caminho, "");

                        if (File.Exists(caminhoBK))
                            File.Delete(caminhoBK);

                        File.Move(caminho, caminhoBK);
                        try
                        {
                            File.Delete(caminho);
                        }
                        catch { }
                        try
                        {
                            for (int i = 0; i < corda2.Length; i++)
                            {
                                File.AppendAllText(caminho, corda1[i]);
                            }
                            File.AppendAllText(caminho, "\r\n");

                            for (int i = 0; i < corda2.Length; i++)
                            {
                                File.AppendAllText(caminho, corda2[i]);
                            }
                            File.AppendAllText(caminho, "\r\n");

                            for (int i = 0; i < corda2.Length; i++)
                            {
                                File.AppendAllText(caminho, corda3[i]);
                            }
                            File.AppendAllText(caminho, "\r\n");

                            for (int i = 0; i < corda2.Length; i++)
                            {
                                File.AppendAllText(caminho, corda4[i]);
                            }
                            File.AppendAllText(caminho, "\r\n");

                            for (int i = 0; i < corda2.Length; i++)
                            {
                                File.AppendAllText(caminho, corda5[i]);
                            }
                            File.AppendAllText(caminho, "\r\n");

                            for (int i = 0; i < corda2.Length; i++)
                            {
                                File.AppendAllText(caminho, corda6[i]);
                            }
                            File.AppendAllText(caminho, "\r\n");

                        }
                        catch
                        {
                            MessageBox.Show("ERRO", "Falha ao salvar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            File.Move(caminhoBK, caminho);
                            File.Delete(caminhoBK);
                        }
                        finally
                        {
                            File.Delete(caminhoBK);
                        }

                        string aux = Path.GetFileName(caminho);

                        string nomeFrm = aux;

                        tabControl.TabPages.Remove(tabControl.SelectedTab);

                        TabPage tp = new TabPage(nomeFrm);
                        tabControl.Controls.Add(tp);
                        saved = true;
                        #endregion
                    }
                }
                saved = true;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saved = false;
            btnSave.PerformClick();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
            if (aa != null)
                aa.GerarTab();
        }

        private void FrmTabCreator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setHTrue();
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setIsMultipleTrue();
            }

            if (e.KeyCode == Keys.X)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setXTrue();
            }

            if (e.KeyCode == Keys.H)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setHTrue();
            }


        }

        private void FrmTabCreator_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setIsMultipleFalse();
            }

            if (e.KeyCode == Keys.X)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setXFalse();
            }

            if (e.KeyCode == Keys.H)
            {
                var aa = Application.OpenForms.OfType<FrmTabs>().FirstOrDefault();
                if (aa != null)
                    aa.setHFalse();
            }

        }

        private void appInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSplashSreen splash = new FrmSplashSreen();
            splash.ShowDialog();
        }
    }
}
