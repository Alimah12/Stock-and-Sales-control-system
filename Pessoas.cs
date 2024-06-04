using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente
{
    public class Pessoas
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public char Sexo { get; set; }
        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Municipio { get; set; }

        public string Estado { get; set; }

        public bool Salvar(Pessoas pessoa)
        {
            try
            {
                using (var sw = new StreamWriter("c:\\dados\\pessoa.txt"))
                {
                    sw.WriteLine(pessoa.Cpf);
                    sw.WriteLine(pessoa.Nome);
                    sw.WriteLine(pessoa.Sexo);
                    sw.WriteLine(pessoa.Endereco);
                    sw.WriteLine(pessoa.Bairro);
                    sw.WriteLine(pessoa.Municipio);
                    sw.WriteLine(pessoa.Estado);
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

    }



}      
