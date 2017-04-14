using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjClasse
{
    public class imc
    {
        //Campos
        private double _peso;
        private double _altura;
        private bool _sexo;

        //Propriedades
        public double peso
        {
            set { _peso = value; }
            get { return _peso; }
        }
        public double altura
        {
            set { _altura = value; } 
            get { return _altura; }
        }
        public bool sexo
        {
            set { _sexo = value; } 
            get { return _sexo; }
        }

        public double IMC
        {
            get {return _peso/Math.Pow(_altura,2);}
        }

        //Métodos
        public void addDados(double peso, double altura, bool sexo)
        {
            _peso = peso;
            _altura = altura;
            _sexo = sexo;
        }

        public void resetDados()
        {
            _peso = 0;
            _altura = 0;
            _sexo = true;
        }

        //Construtor
        public imc()
        {
            _peso = 0;
            _altura = 0;
            _sexo = true;
        }
    }
}
