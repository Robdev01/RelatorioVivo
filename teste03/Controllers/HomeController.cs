using System.Diagnostics;
using FastReport.Export.PdfSimple;
using FastReport;
using Microsoft.AspNetCore.Mvc;
using teste03.Models;
using System.IO;

namespace teste03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Cabecalho
            {
                area = "",
                estado = "",
                usuario = "",
                empresa = "",
                inicio = DateTime.Now,
                fim = DateTime.Now,
                envio = DateTime.Now,
                aprovado = "",
                aprovacao = "",
                cod = "",
                numeroATP = "",
                cliente = "",
                endereco = "",
                municipio = "",
                uf = "",
                areaAT = "",
                status = "",
                certi = "",
                numeroCert = "",
                valorCent = "",
                obsCe = "",
                valCabo = "",
                obsAndarDoCen = "",
                valAdarDoCen = "",
                obsValdenCabo = "",
                img1 = null,
                obsImg1 = ""
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GerarRelatorioAsync(Cabecalho model)
        {
            ViewBag.Error = null;
            byte[] imageBytes = null;

            // Verificar se o arquivo de imagem foi enviado
            if (model.img1 != null && model.img1.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Copiar a imagem para o MemoryStream
                    await model.img1.CopyToAsync(memoryStream);

                    // Converter a imagem para um array de bytes
                    imageBytes = memoryStream.ToArray();
                }
            }

            // Verifica se o modelo é válido
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Alguns campos não foram preenchidos corretamente.";
                return View("Index", model);
            }

            try
            {
                _logger.LogInformation("Recebido formulário para gerar relatório com os seguintes dados: {@Model}", model);

                // Carregar o relatório
                string caminhoRelatorio = Path.Combine(Directory.GetCurrentDirectory(), @"Relatorio\Teste.frx");
                Report report = Report.FromFile(caminhoRelatorio);

                // Configurar os parâmetros do relatório
                report.SetParameterValue("area", model.area);
                report.SetParameterValue("estado", model.estado);
                report.SetParameterValue("usuario", model.usuario);
                report.SetParameterValue("empresa", model.empresa);
                report.SetParameterValue("inicio", model.inicio);
                report.SetParameterValue("fim", model.fim);
                report.SetParameterValue("aprovado", model.aprovado);
                report.SetParameterValue("aprovacao", model.aprovacao);
                report.SetParameterValue("envio", model.envio);
                report.SetParameterValue("cod", model.cod);
                report.SetParameterValue("numeroATP", model.numeroATP);
                report.SetParameterValue("cliente", model.cliente);
                report.SetParameterValue("endereco", model.endereco);
                report.SetParameterValue("municipio", model.municipio);
                report.SetParameterValue("uf", model.uf);
                report.SetParameterValue("areaAT", model.areaAT);
                report.SetParameterValue("status", model.status);
                report.SetParameterValue("certi", model.certi);
                report.SetParameterValue("numeroCert", model.numeroCert);
                report.SetParameterValue("valorCent", model.valorCent);
                report.SetParameterValue("obsCe", model.obsCe);
                report.SetParameterValue("valCabo", model.valCabo);
                report.SetParameterValue("obsAndarDoCen", model.obsAndarDoCen);
                report.SetParameterValue("valAdarDoCen", model.valAdarDoCen);
                report.SetParameterValue("obsValdenCabo", model.obsValdenCabo);
                report.SetParameterValue("obsImg1", model.obsImg1);

                // Passar a imagem diretamente como byte array para o relatório
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    report.SetParameterValue("img1", imageBytes);
                }

                // Preparar o relatório
                report.Prepare();

                // Exportar para PDF
                using var pdfExport = new PDFSimpleExport();
                using var reportStream = new MemoryStream();
                pdfExport.Export(report, reportStream);
                reportStream.Position = 0;

                // Retornar o arquivo PDF como resposta
                return File(reportStream.ToArray(), "application/pdf", "Relatorio.pdf");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro ao gerar o relatório: {ex.Message}";
                return View("Index", model);
            }
        }
    }
}

