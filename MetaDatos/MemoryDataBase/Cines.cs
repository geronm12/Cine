using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaDatos.MemoryDataBase
{
    public class Cines
    {
        [ScaffoldColumn(false)]
        public long? Id { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.MultilineText)]
        public string Resumen { get; set; }

        [DataType(DataType.Password)]
        public string Contraseñita { get; set; }

        public string Dirección { get; set; }

        public string País { get; set; }

        public long DueñoId { get; set; }

        public string NombreCine { get; set; }

        public ICollection<Salones> _Salones { get; set; }


         

        public List<Cines> ListaCines(List<Cines> lista)
        {
            var cine1 = new Cines
            {
                Dirección = "Avenida Solano Vera",
                NombreCine = "Solar",
                País = "Argentina",
                DueñoId = 1,
                _Salones = new List<Salones>
                {
                    new Salones
                    {
                        CapacidadMáx = 100,
                        NumeroSalon = 1,
                        Peliculas = new List<Peliculas>
                        {
                            new Peliculas
                            {
                                DirectorId = 2,
                                Duración = 120,
                                FechaDeCreacion = new DateTime(2018, 12, 12),
                                Nombre = "Dragon ball Super Broly",
                                País = "Japón",
                                TipoDePelicula = PeliculaTipo.Animada,
                                URL = "https://vignette.wikia.nocookie.net/dragonball/images/f/fb/Dragon_Ball_Super_Broly_poster.png/revision/latest?cb=20180709221734&path-prefix=es",
                                TrailerURL = "https://www.youtube.com/embed/dl3w10VVQj8",
                                Entradas = new Entradas
                                {
                                    Cantidad = 100,
                                    Precio = 200
                                }

                            },
                            new Peliculas
                            {
                                DirectorId = 2,
                                Duración = 120,
                                FechaDeCreacion = new DateTime(2018, 5, 22),
                                Nombre = "My Hero Academia: Two Heroes",
                                País = "Japón",
                                TipoDePelicula = PeliculaTipo.Animada,
                                URL = "https://musicart.xboxlive.com/7/0cf85000-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080",
                                TrailerURL = "https://www.youtube.com/embed/hk5ZLDFAFsc",
                                Entradas = new Entradas
                                {
                                    Cantidad = 150,
                                    Precio = 150
                                }
                            }

                        },

                    },
                    new Salones
                    {
                        CapacidadMáx = 200,
                        NumeroSalon = 2,
                        Peliculas = new List<Peliculas>
                        {
                            new Peliculas
                            {
                               DirectorId = 3,
                               Duración = 180,
                               FechaDeCreacion = new DateTime(2019, 10,10),
                               Nombre  = "Avengers: End Game",
                               País = "Estados Unidos",
                               TipoDePelicula = PeliculaTipo.Accion,
                               URL = "https://pulpfictioncine.com/download/multimedia.normal.a1078dc7561a9f2b.6176656e676572735f6e6f726d616c2e6a706567.jpeg",
                               TrailerURL = "https://www.youtube.com/embed/znk2OICHbjY",
                               Entradas = new Entradas{Cantidad = 150, Precio = 300}

                            },
                            new Peliculas
                            {
                                DirectorId = 4,
                                Duración = 180,
                                FechaDeCreacion = new DateTime(2019, 10, 12),
                                Nombre = "Joker",
                                País = "Estados Unidos",
                                TipoDePelicula = PeliculaTipo.Accion,
                                URL = "https://i.pinimg.com/originals/4d/d8/91/4dd891b493bd5f5a3581cd1d0cf9d332.jpg",
                                TrailerURL = "https://www.youtube.com/embed/zAGVQLHvwOY",
                                Entradas = new Entradas{Cantidad = 200, Precio = 350}

                            }
                        }

                    }


                }
            };

            lista.Add(cine1);

            return lista;

        }
    }
}
