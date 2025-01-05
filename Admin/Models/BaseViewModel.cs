using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Admin.Models
{
    public class BaseViewModel
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get { return TotalRegistros % Take == 0 ? TotalRegistros / Take
                : (TotalRegistros / Take) + 1; } }
        public int TotalRegistros { get; set; }
        public int Take { get; set; } = 10;
        public int Skip { get { return PaginaAtual <= 1 ? 0 : (PaginaAtual - 1) * Take; } }

        public void ConfigurarPaginacao()
        {
            //TotalPaginas = TotalRegistros % Take == 0 ? TotalRegistros / Take 
            //    : (TotalRegistros / Take) + 1;
        }
    }
}
