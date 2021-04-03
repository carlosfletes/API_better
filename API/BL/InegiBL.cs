using API.Contracts;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.BL
{
    public class InegiBL : IInegi
    {
        private List<AnioDTO> _anioDTOList { get; set; }

        public InegiBL()
        {
            _anioDTOList = new List<AnioDTO>();
        }
        public AnioDTO GetAnio(List<InegiDTO> inegiList)
        {

            int menor = inegiList.Min(item => item.Nacimiento);
            int mayor = inegiList.Max(item => item.Muerte);

            int cuantos = 0;
            for (int anio = menor; anio <= mayor; anio++)
            {
                //Busco cuantas personas vivieron entre ese año
                cuantos = inegiList.Count(item => item.Nacimiento <= anio && item.Muerte >= anio);

                //Genero el elemento con el resultado
                AnioDTO anioDTO = new AnioDTO
                {
                    Anio = anio,
                    PersonasVivas = cuantos
                };

                _anioDTOList.Add(anioDTO);

            }

            //esta es la cantidad mayor de personas vivas
            mayor = _anioDTOList.Max(item => item.PersonasVivas);

            AnioDTO anioResultado = _anioDTOList.Where(item => item.PersonasVivas.Equals(mayor)).FirstOrDefault();

            return anioResultado;
        }
    }
}
