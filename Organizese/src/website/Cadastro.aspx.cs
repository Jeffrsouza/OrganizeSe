using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src.website
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string dtNas = dtNascimento.Value;
            string genero = rblGen.SelectedValue;

            bool ok = true;
            if (txtSenha.Text != txtSenha2.Text) {
                ok = false;
                ltlErro.Text = "Senhas não conferem";
                return;
            }

            if(string.IsNullOrEmpty(txtNome.Text)) ok = false;
            if(string.IsNullOrEmpty(txtSobrenome.Text)) ok = false;
            if(string.IsNullOrEmpty(txtCpf.Text)) ok = false;
            if(string.IsNullOrEmpty(txtEmail.Text)) ok = false;
            if(string.IsNullOrEmpty(txtSenha.Text)) ok = false;
            if(string.IsNullOrEmpty(txtSenha2.Text)) ok = false;
            if(string.IsNullOrEmpty(dtNas)) ok = false;

            if (ok)
            {
                LinkGeral lnk = new LinkGeral();
                bool gravado = lnk.GravarUsuario(txtNome.Text, txtSobrenome.Text, txtEmail.Text, txtCpf.Text,  txtSenha.Text, genero,dtNas );
                if (gravado) Response.Redirect("www.organizeseop.com.br");
                else ltlErro.Text = "Erro ao gravar dados, por favor verifique os campos.";
            }
            else
            {
                ltlErro.Text = "Dados incorretos, por favor verifique os campos.";
            }
        }
    }
}