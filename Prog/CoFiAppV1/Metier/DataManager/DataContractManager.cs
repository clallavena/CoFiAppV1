using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Metier.DataManager
{
    public class DataContractManager : IDataManager
    {
        public IEnumerable<Film> ChargementFilms()
        {
            var serializerListFilm = new DataContractSerializer(typeof(List<Film>));

            List<Film> deserialized;
            try
            {
                using (Stream stream = File.OpenRead("../../../Metier/XML/List_Film.xml"))
                {
                    deserialized = serializerListFilm.ReadObject(stream) as List<Film>;
                }
                return deserialized;
            }
            catch(FileNotFoundException ex)
            {
                File.Create("../../../Metier/XML/List_Film.xml");
                Debug.WriteLine(ex);
                return null;
            }            
        }

        public void SauvegardeFilms(IEnumerable<Film> films)
        {
            var serializerListFilm = new DataContractSerializer(typeof(List<Film>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("../../../Metier/XML/List_Film.xml", settings))
            {
                serializerListFilm.WriteObject(writer, films);
            }
        }

        public ObservableCollection<Personne> ChargementReal()
        {
            var serializerListReals = new DataContractSerializer(typeof(ObservableCollection<Personne>));

            ObservableCollection<Personne> deserialized;
            try
            {
                using (Stream stream = File.OpenRead("../../../Metier/XML/List_Reals.xml"))
                {
                    deserialized = serializerListReals.ReadObject(stream) as ObservableCollection<Personne>;
                }
                return deserialized;
            }
            catch (FileNotFoundException ex)
            {
                File.Create("../../../Metier/XML/List_Reals.xml");
                Debug.WriteLine(ex);
                return null;
            }            
        }

        public void SauvegardeReal(ObservableCollection<Personne> personnes)
        {
            var serializerListReals = new DataContractSerializer(typeof(ObservableCollection<Personne>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("../../../Metier/XML/List_Reals.xml", settings))
            {
                serializerListReals.WriteObject(writer, personnes);
            }
        }

        public IEnumerable<Admin> ChargementAdmin()
        {
            List<Admin> admins = new List<Admin>
            {
                new Admin("esbarland", "coucou"),
                new Admin("clallavena", "bigboss")
            };

            return admins;
        }
    }
}
