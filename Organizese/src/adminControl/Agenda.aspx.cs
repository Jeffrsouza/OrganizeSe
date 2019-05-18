using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Organizese.src.adminControl
{
    public partial class Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                website.Login.id = "1";
                website.Login.nome = "JEFF";
                website.Login.tipo = "ADMIN";
                LoadTime();
                CarregarAgenda();
                CarregarAtendimentos();
            }
        }

        private void LoadTime()
        {
            ddlHora.Items.Add("07:00");
            ddlHora.Items.Add("07:30");
            ddlHora.Items.Add("08:00");
            ddlHora.Items.Add("08:30");
            ddlHora.Items.Add("09:00");
            ddlHora.Items.Add("09:30");
            ddlHora.Items.Add("10:00");
            ddlHora.Items.Add("10:30");
            ddlHora.Items.Add("11:00");
            ddlHora.Items.Add("11:30");
            ddlHora.Items.Add("12:00");
            ddlHora.Items.Add("12:30");
            ddlHora.Items.Add("13:00");
            ddlHora.Items.Add("13:30");
            ddlHora.Items.Add("14:00");
            ddlHora.Items.Add("14:30");
            ddlHora.Items.Add("15:00");
            ddlHora.Items.Add("15:30");
            ddlHora.Items.Add("16:00");
            ddlHora.Items.Add("16:30");
            ddlHora.Items.Add("17:00");
            ddlHora.Items.Add("17:30");
            ddlHora.Items.Add("18:00");
            ddlHora.Items.Add("18:30");
            ddlHora.Items.Add("19:00");
            ddlHora.Items.Add("19:30");
            ddlHora.Items.Add("20:00");
            ddlHora.Items.Add("20:30");
            ddlHora.Items.Add("21:00");
            ddlHora.Items.Add("21:30");
            ddlHora.Items.Add("22:00");
            ddlHora.Items.Add("22:30");
            ddlHora.Items.Add("23:00");

            DateTime today = DateTime.Today.AddDays(1);
            dtAgenda.TodaysDate = today;
            dtAgenda.SelectedDate = dtAgenda.TodaysDate;
        }

        protected void CarregarAgenda()
        {
            LinkGeral lnk = new LinkGeral();
            DataTable dt = lnk.CarregarAgenda(website.Login.id);
            rptAgenda.DataSource = dt;
            rptAgenda.DataBind();

        }

        protected void CarregarAtendimentos()
        {
            LinkGeral lnk = new LinkGeral();
            rptAtendimentos.DataSource = lnk.CarregarAtendimentos(website.Login.id);
            rptAtendimentos.DataBind();
        }

        protected void btnNovoHorario_Click(object sender, EventArgs e)
        {
            DateTime data = dtAgenda.SelectedDate;
            string hora = ddlHora.SelectedValue;

            LinkGeral lnk = new LinkGeral();
            bool ok = lnk.InserirAgenda(website.Login.id, data, hora);
            if (ok) CarregarAgenda();
        }

        protected void btnOpenAtd_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            LinkGeral lnk = new LinkGeral();
            bool ok = lnk.IniciarAtendimento(btn.CommandArgument.ToString());

            if (ok)
            {
                website.Atendimento.id = btn.CommandArgument.ToString();
                Response.Redirect("~/src/adminControl/Chat.aspx");
            }
            else
            {
                //Retorna algum erro
            }
        }
    }
}