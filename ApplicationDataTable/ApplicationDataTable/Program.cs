using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace ApplicationDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = GetTable();

            var lista = CrearListaPersonas();

            try
            {
                table = ConvertToDataTable(lista);
                Console.WriteLine("Creó tabla");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            Console.ReadKey();
        }

        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable("Pruebas");
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }


        static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable("Persona");

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        static List<Persona> CrearListaPersonas()
        {
            var listaPersonas = new List<Persona>();
            var listaTelefonos = new List<Telefono>();
            var telefono = new Telefono();

            telefono = new Telefono() { Descripcion = "Telefono de Casa", Numero = "0424978458" };
            listaTelefonos.Add(telefono);
            telefono = new Telefono() { Descripcion = "Telefono de Casa opcional", Numero = "0424978459" };
            listaTelefonos.Add(telefono);
            listaPersonas.Add(new Persona { Codigo = 8952, CodigoEntidad = 602070, Fecha = DateTime.MinValue, NombresApellidos = "ARREGUI DAVILA ABEL ARMANDO", Monto = (decimal)48.58, Telefonos = listaTelefonos });

            listaTelefonos.Clear();
            telefono = new Telefono() { Descripcion = "Telefono de Casa", Numero = "0424978445" };
            listaTelefonos.Add(telefono);
            listaPersonas.Add(new Persona { Codigo = 9336, CodigoEntidad = 602070, Fecha = DateTime.MinValue, NombresApellidos = "ARREGUI MOREJON EDWIN PAUL", Monto = (decimal)20.58, Telefonos = listaTelefonos });

            listaTelefonos.Clear();
            telefono = new Telefono() { Descripcion = "Celular", Numero = "0997598748" };
            listaTelefonos.Add(telefono);
            listaPersonas.Add(new Persona { Codigo = 26068, CodigoEntidad = 602070, Fecha = DateTime.MinValue, NombresApellidos = "ARREGUI ROMERO SANDRA LISSETTE", Monto = (decimal)30.15, Telefonos = listaTelefonos });

            listaTelefonos.Clear();
            telefono = new Telefono() { Descripcion = "Celular Personal", Numero = "0887598748" };
            listaTelefonos.Add(telefono);
            telefono = new Telefono() { Descripcion = "Convencional", Numero = "042787878" };
            listaTelefonos.Add(telefono);
            listaPersonas.Add(new Persona { Codigo = 8952, CodigoEntidad = 602070, Fecha = DateTime.MinValue, NombresApellidos = "ARREGUI DAVILA ABEL ARMANDO", Monto = (decimal)60.58, Telefonos = listaTelefonos });

            listaTelefonos.Clear();
            telefono = new Telefono() { Descripcion = "Convencional", Numero = "052787878" };
            listaTelefonos.Add(telefono);
            listaPersonas.Add(new Persona { Codigo = 26069, CodigoEntidad = 602070, Fecha = DateTime.MinValue, NombresApellidos = "ARREGUI ROMERO WASHINGTON ARMANDO", Monto = (decimal)99.58, Telefonos = listaTelefonos });

            return listaPersonas;
        }
    }

    public class Persona
    {
        public long Codigo { get; set; }
        public long CodigoEntidad { get; set; }
        public string TipoRelacion { get; set; }
        public string NombresApellidos { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string RucCedula { get; set; }
        public string Direccion { get; set; }
        public List<Telefono> Telefonos { get; set; }
        public string Observaciones { get; set; }
    }

    public class Telefono
    {
        public string Numero { get; set; }
        public string Descripcion { get; set; }
    }
}


