using GestaoTestes.Arquivos.ModuloDisciplina;
using GestaoTestes.Arquivos.ModuloMateria;
using GestaoTestes.Arquivos.ModuloQuestao;
using GestaoTestes.Arquivos.ModuloTeste;
using GestaoTestes.Infra.Arquivos;
using GestaoTestes.Infra.BancoDados.ModuloDisciplina;
using GestaoTestes.Infra.BancoDados.ModuloMateria;
using GestaoTestes.Infra.BancoDados.ModuloQuestao;
using GestaoTestes.WinApp.Compartilhado;
using GestaoTestes.WinForm.ModuloDisciplina;
using GestaoTestes.WinForm.ModuloMatéria;
using GestaoTestes.WinForm.ModuloQuestao;
using GestaoTestes.WinForm.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoTestes.WinForm
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        private DataContext dataContext;


        public TelaPrincipalForm(DataContext dataContext) 
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            this.dataContext = dataContext;

            InicializarControladores();
        }

        private void InicializarControladores()
        {
            var reposotorioDisciplina = new RepositorioDisciplinaEmBancoDados();
            var repositorioMateria = new RepositorioMateriaEmBancoDados();
            var repositorioQuestao = new RepositorioQuestaoEmBancoDados();

            var repositorioTeste = new RepositorioTesteEmArquivo(dataContext);


            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Disciplina", new ControladorDisciplina(reposotorioDisciplina));
            controladores.Add("Matéria", new ControladorMateria(repositorioMateria, reposotorioDisciplina));
            controladores.Add("Questão", new ControladorQuestao(repositorioQuestao, repositorioMateria, reposotorioDisciplina));

            controladores.Add("Teste", new ControladorTeste(repositorioTeste, reposotorioDisciplina, repositorioMateria, repositorioQuestao));
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set; 
        }
        public void AtualizarRodape(string messagem)
        {
            labelRodape.Text = messagem;
        }

        private void disciplinaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }
        private void materiaItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }
        private void questaoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }
        private void testeMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);

        }
       
        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemConstrol = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemConstrol.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemConstrol);
        }

       

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);

            }
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;

        }

       

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

              
    }
    

}