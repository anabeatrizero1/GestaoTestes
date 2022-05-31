using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using GestaoTestes.Dominio.ModuloQuestao;
using GestaoTestes.Dominio.ModuloTeste;
using GestaoTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private TabelaTesteControl tabelaTeste;

        private readonly IRepositorioTeste repositorioTeste;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioDisciplina repositorioDisciplina;
        private readonly IRepositorioQuestao repositorioQuestao;


        public ControladorTeste(IRepositorioTeste repositorioTeste,
            IRepositorioDisciplina repositorioDisciplina, 
            IRepositorioMateria repositorioMateria,
            IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioTeste = repositorioTeste;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;

        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTeste();
        }

        public override UserControl ObtemListagem()
        {
            tabelaTeste = new TabelaTesteControl();

            CarregarTestes();

            return tabelaTeste;
        }

        public override void Inserir()
        {
            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var materias = repositorioMateria.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, questoes);

            tela.Teste = new Teste();
                      

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Editar()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiroS.",
                "Edição de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var materias = repositorioMateria.SelecionarTodos();
            var disciplinas = repositorioDisciplina.SelecionarTodos();
            var questoes = repositorioQuestao.SelecionarTodos();

            TelaCadastroTesteForm tela = new TelaCadastroTesteForm(disciplinas, materias, questoes);
            
            tela.Teste = testeSelecionado;

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }
        }

        public override void Excluir()
        {
            Teste testeSelecionado = ObterTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Exclusão de Teste", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Teste?",
               "Exclusão de Teste", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }


        #region Métodos Privadas
        private Teste ObterTesteSelecionado()
        {
            var numero = tabelaTeste.ObtemNumeroTesteSelecionado();

            return repositorioTeste.SelecionarPorNumero(numero);
        }
        private void CarregarTestes()
        {
            List<Teste> testes = repositorioTeste.SelecionarTodos();

            tabelaTeste.AtualizarRegistros(testes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {testes.Count} teste(s)");
        }
        #endregion 
    }
}
