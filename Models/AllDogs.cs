using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrograFinalDefinitivoP2.Models
{
    internal class AllDogs
    {

        public ObservableCollection<Dog> Dogs { get; set; } = new ObservableCollection<Dog>();
        public AllDogs() =>
        LoadDogs();

        public void LoadDogs()
        {
            Dogs.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Dog> dogs = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.dogs.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Dog()
                                        {
                                            Filename = filename,
                                            Name = File.ReadAllLines(filename)[0],
                                            Age = File.ReadAllLines(filename)[1],
                                            Address= File.ReadAllLines(filename)[2],
                                            Description= File.ReadAllLines(filename)[3],
                                            Color= File.ReadAllLines(filename)[4],
                                            Size= File.ReadAllLines(filename)[5],
                                            Email= File.ReadAllLines(filename)[6],
                                            imageRoute = File.ReadAllLines(filename)[7]
                                        }); 

            foreach (Dog dog in dogs)
                Dogs.Add(dog);
        }
    }
}
