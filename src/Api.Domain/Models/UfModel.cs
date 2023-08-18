using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class UfModel : BaseModel
    {


        private string _sigla;
        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

        private string _nameUf;
        public string NameUf
        {
            get { return _nameUf; }
            set { _nameUf = value; }
        }
    }
}
