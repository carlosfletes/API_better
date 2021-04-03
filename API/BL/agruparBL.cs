using API.Contracts;
using API.Models;
using System.Collections.Generic;
using System.Linq;


namespace API.BL
{
    public class agruparBL : IAgrupar
    {

        private List<Distribuidor> _distribuidorList;

        public agruparBL()
        {
            _distribuidorList = new List<Distribuidor>();
        }

        public List<Distribuidor> agregarAsociacion(List<RelacionDTO> data)
        {
            foreach (RelacionDTO objeto in data)
            {
                //Valido si ya existe el distribuidor 
                if (!_distribuidorList.Any(item => item.Nombre.Equals(objeto.distribuidor)))
                {
                    Distribuidor distribuidor = new Distribuidor();
                    distribuidor.Nombre = objeto.distribuidor;

                    Asociado asociado = new Asociado();
                    asociado.Nombre = objeto.asociado;

                    distribuidor.ListaAsociados = new List<Asociado>();

                    distribuidor.ListaAsociados.Add(asociado);

                    _distribuidorList.Add(distribuidor);
                }
                else
                {
                    //Obtengo el distribuidor que se envía
                    Distribuidor distribuidor;
                    distribuidor = _distribuidorList.Where(item => item.Nombre.Equals(objeto.distribuidor)).FirstOrDefault();

                    //Busco si ya tiene el asociado
                    if (!distribuidor.ListaAsociados.Any(item => item.Nombre.Equals(objeto.asociado)))
                    {
                        Asociado asociado = new Asociado();
                        asociado.Nombre = objeto.asociado;
                        distribuidor.ListaAsociados.Add(asociado);
                    }
                }

            }

            return _distribuidorList;
        }

        public List<Distribuidor> GetDistribuidors(string data)
        {
           return System.Text.Json.JsonSerializer.Deserialize<List<Distribuidor>>(data);

        }
    }
}
