using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Newtonsoft.Json;

namespace Api.Integration.Test.Uf
{
    public class CrudUf : BaseIntegration
    {
        public Guid _idUf { get; set; }

        public string _sigla { get; set; }

        public string _nameUf { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Uf()
        {


            _idUf = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee");
            _sigla = "PB";
            _nameUf = "Paraíba";

            var ufDto = new UfDto
            {
                Id = _idUf,
                Sigla = _sigla,
                NameUf = _nameUf
            };

            await AdicionarToken();

            //GET ALL
            response = await client.GetAsync($"{hostApi}ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var resgistroGetAll = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(resgistroGetAll);
            Assert.True(resgistroGetAll.Count() == 27);
            Assert.True(resgistroGetAll.Where(r => r.Id == ufDto.Id).Count() == 1);

            //GET ID
            response = await client.GetAsync($"{hostApi}ufs/{ufDto.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var objetoSelecionado = JsonConvert.DeserializeObject<UfDto>(jsonResult);

            Assert.NotNull(objetoSelecionado);
            Assert.Equal(_nameUf, objetoSelecionado.NameUf);
            Assert.Equal(_sigla, objetoSelecionado.Sigla);

            //GET SIGLA
            response = await client.GetAsync($"{hostApi}ufs/bySigla/{ufDto.Sigla}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var objetoSelecionadoSigla = JsonConvert.DeserializeObject<UfDto>(jsonResult);

            Assert.NotNull(objetoSelecionado);
            Assert.Equal(_nameUf, objetoSelecionado.NameUf);
            Assert.Equal(_sigla, objetoSelecionado.Sigla);
        }
    }
}
