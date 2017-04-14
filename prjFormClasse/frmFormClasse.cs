using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjFormClasse
{
    public partial class frmFormClasse : Form
    {
        public frmFormClasse()
        {
            InitializeComponent();
        }


        #region habilitarCálculo

        #region Método
        private void enableCalc()
        {
            if (txtAltura.Text.Length > 0 && txtPeso.Text.Length > 0 && (rbtnFem.Checked || rbtnMasc.Checked))
            {
                btnCalc.Enabled = true;
            }
            else
            {
                btnCalc.Enabled = false;
            }
        }
        #endregion

        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            enableCalc();
        }
        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            enableCalc();
        }
        private void rbtnMasc_CheckedChanged(object sender, EventArgs e)
        {
            enableCalc();
        }
        private void rbtnFem_CheckedChanged(object sender, EventArgs e)
        {
            enableCalc();
        }
        #endregion

        #region Calcular
        private void btnCalc_Click(object sender, EventArgs e)
        {
            double Alt, Pes;

            //Verifica o tipo do conteúdo
            try
            {
                Alt = double.Parse(txtAltura.Text);
                Pes = double.Parse(txtPeso.Text);
            }
            catch
            {
                MessageBox.Show("Insira somente números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            //Verifica se o sexo está selecionado
            if (rbtnMasc.Checked || rbtnFem.Checked)
            {
                //Usa a Classe
                prjClasse.imc imc = new prjClasse.imc();

                #region Verifica o peso
                    if (rbtnMasc.Checked)
                    {
                        imc.addDados(Pes, Alt, true); //adiciona dados

                        if (imc.IMC < 19)
                        {
                            lblRes.Text = "  Muito magro!";
                            pcbImagem.Image = prjFormClasse.Properties.Resources.Magro;
                        }
                        else
                        {
                            if (imc.IMC > 32)
                            {
                                lblRes.Text = "  Muito gordo!";
                                pcbImagem.Image = prjFormClasse.Properties.Resources.Gordo;
                            }
                            else
                            {
                                lblRes.Text = "  Peso ideal";
                                pcbImagem.Image = prjFormClasse.Properties.Resources.Homem;
                            }
                        }
                    }
                    else
                    {
                        imc.addDados(Pes, Alt, false); //adiciona dados

                        if (imc.IMC < 20)
                        {
                            lblRes.Text = "  Muito magra!";
                            pcbImagem.Image = prjFormClasse.Properties.Resources.Magra;
                        }
                        else
                        {
                            if (imc.IMC > 31)
                            {
                                lblRes.Text = "  Muito gorda!";
                                pcbImagem.Image = prjFormClasse.Properties.Resources.Gorda;
                            }
                            else
                            {
                                lblRes.Text = "  Peso ideal";
                                pcbImagem.Image = prjFormClasse.Properties.Resources.Mulher;
                            }
                        }

                    }
                    #endregion

                txtIMC.Text = imc.IMC.ToString();
                txtIMC.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecione seu sexo", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        #endregion

        #region Limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAltura.Clear();
            txtPeso.Clear();
            pcbImagem.Image = null;
            lblRes.Text = "Insira seus dados";
            txtIMC.Text = "IMC";
        }
        #endregion

        #region Sair
        private void frmFormClasse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?","Sair",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
