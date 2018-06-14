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

namespace Metier.DataManager
{
    public class DataContractManager : IDataManager
    {
        /// <summary>
        /// Chargement des films depuis un fichier XML
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Film> ChargementFilms()
        {
            var serializerListFilm = new DataContractSerializer(typeof(List<Film>));

            List<Film> deserialized;
            try
            {
                using (Stream stream = File.OpenRead("../../../Metier/XML/List_Film.xml"))
                {
                    if (stream.Length == 0) return null;
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

        /// <summary>
        /// Sauvegarde des films dans un fichier XML
        /// </summary>
        /// <param name="films"></param>
        public void SauvegardeFilms(IEnumerable<Film> films)
        {
            var serializerListFilm = new DataContractSerializer(typeof(List<Film>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("../../../Metier/XML/List_Film.xml", settings))
            {
                serializerListFilm.WriteObject(writer, films);
            }
        }

        /// <summary>
        /// Chargement des réalisateurs depuis un fichier XML
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Personne> ChargementReal()
        {
            var serializerListReals = new DataContractSerializer(typeof(ObservableCollection<Personne>));

            ObservableCollection<Personne> deserialized;
            try
            {
                using (Stream stream = File.OpenRead("../../../Metier/XML/List_Reals.xml"))
                {
                    if (stream.Length == 0) return null;
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

        /// <summary>
        /// Sauvegarde des réalisateurs dans un fichier XML
        /// </summary>
        /// <param name="personnes"></param>
        public void SauvegardeReal(ObservableCollection<Personne> personnes)
        {
            var serializerListReals = new DataContractSerializer(typeof(ObservableCollection<Personne>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("../../../Metier/XML/List_Reals.xml", settings))
            {
                serializerListReals.WriteObject(writer, personnes);
            }
        }

        /// <summary>
        /// Chargement des administrauteurs en dur
        /// </summary>
        /// <returns></returns>
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
