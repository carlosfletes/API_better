using API.Models;
using System.Collections.Generic;

namespace API.Contracts
{
    public interface IAgrupar
    {
        List<Distribuidor> agregarAsociacion(List<RelacionDTO> data);

        public List<Distribuidor> GetDistribuidors(string data);
    }
}
