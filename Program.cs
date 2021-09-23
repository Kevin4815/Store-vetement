using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace magasin_vetements
{
    class Tshirt : Articles
    {
        string letterSize;

        public Tshirt(string type, string mark, string color, float price, string letterSize) : base(type, mark, color, price)
        {
            this.letterSize = letterSize;
        }

        public override void Display()
        {
            InfosClothe();
            Console.WriteLine("TAILLE : " + letterSize);
            Console.WriteLine();
        }
    }
    class Jeans : Articles
    {
        int numberSize;
        public Jeans(string type, string mark, string color, float price, int numberSize) : base (type, mark, color, price)
        {
            this.numberSize = numberSize;
        }

        public override void Display()
        {
            InfosClothe();
            Console.WriteLine("TAILLE : " + numberSize);
            Console.WriteLine();
        }
    }
    class Articles
    {
        public string type;
        public string mark;
        public string color;
        protected float price;
        
        public Articles(string type, string mark, string color, float price)
        {
            this.type = type;
            this.mark = mark;
            this.color = color;
            this.price = price;
        }

        public virtual void Display()
        {
            InfosClothe();
        }

        protected void InfosClothe()
        {
            Console.WriteLine("TYPE : " + type);
            Console.WriteLine("MARQUE : " + mark);
            Console.WriteLine("COULEUR : " + color);
            Console.WriteLine("PRIX : " + price + "€");
        }
    }
    class Program
    {
        static List<Articles> ShowArticles(List<Articles> articles)
        {
            Console.WriteLine("Que souhaitez-vous faire ?\n" +
               "1 - Voir tous les articles\n" +
               "2 - Faire une recherche");

            string choice_str = Console.ReadLine();
            Console.Clear();
            try
            {
                int choice_int = int.Parse(choice_str);

                if (choice_int == 1)
                {
                    return articles;
                }
                else if (choice_int == 2)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("ERREUR : Ce numéro n'existe pas");
                    Console.WriteLine();
                    return ShowArticles(articles);
                }
            }
            catch
            {
                Console.WriteLine("ERREUR : Vous devez rentrer un numéro");
                Console.WriteLine();
                return ShowArticles(articles);
            }
        }

        static void WhatArticlesSearch(List<Articles> articles)
        {
            Console.WriteLine("Vous souhaitez faire une recherche par :\n" +
                    "1 - Type\n" +
                    "2 - Marque\n" +
                    "3 - Couleur");

            string searchBy_str = Console.ReadLine();
            Console.Clear();

            try
            {
                int searchBy_int = int.Parse(searchBy_str);

                switch (searchBy_int)
                {
                    case 1:
                        Console.WriteLine("Entrez un type de vêtement : ");
                        string type = Console.ReadLine();
                        articles = articles.Where(t => t.type.ToLower().Contains(type)).ToList();
                        DisplayArticle(articles);

                        break;
                    case 2:
                        Console.WriteLine("Entrez une marque de vêtement : ");
                        string mark = Console.ReadLine();
                        articles = articles.Where(m => m.mark.ToLower().Contains(mark)).ToList();
                        DisplayArticle(articles);
                        break;
                    case 3:
                        Console.WriteLine("Entrez une couleur de vêtement : ");
                        string color = Console.ReadLine();
                        articles = articles.Where(c => c.color.ToLower().Contains(color)).ToList();
                        DisplayArticle(articles);
                        break;

                    default:
                        Console.WriteLine("ERREUR : Votre choix n'est pas valide");
                        WhatArticlesSearch(articles);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("ERREUR : Vous devez entrer un nombre");
                WhatArticlesSearch(articles);
            }
        }

        static void DisplayArticle(List<Articles> articles)
        {
            if (articles.Count > 0)
            {
                Console.WriteLine();
                foreach (var a in articles)
                {
                    a.Display();
                }
            }
            else
            {
                Console.WriteLine("----- Aucun article trouvé -----");
                Console.WriteLine();
                //QuiteOrContinue(articles);
            }
        }

       /* static void QuiteOrContinue(List<Articles> articles)
        {
            Console.WriteLine("1 - Tenter une autre recherche\n" +
                "2 - Retour au menu principal");
            string response_str = Console.ReadLine();
            int response_int = int.Parse(response_str);
            Console.Clear();

            if(response_int == 1)
            {
                WhatArticlesSearch(articles);
            }
            else if(response_int == 2)
            {
                ShowArticles(articles);
            }
        }*/

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var articles = new List<Articles>()
            {
                new Jeans("Jeans", "Caporal", "Bleu", 45.95f, 42),
                new Jeans("Jeans", "Tommy Hilfiger", "Noir", 99.99f, 40),
                new Jeans("Jeans", "Jack & Jones", "Bleu clair", 50f, 38),
                new Jeans("Jeans", "Gustin", "Gris", 70f, 44),
                new Tshirt("T-shirt", "Caporal", "Rouge", 25.50f, "M"),
                new Tshirt("T-shirt", "Tommy Hilfiger", "Blanc", 45.90f, "L"),
                new Tshirt("T-shirt", "Jack & Jones", "Bleu", 30f, "S"),
                new Tshirt("T-shirt", "Diesel", "Gris", 59.90f, "XL")
            };

            var showArticles = ShowArticles(articles);

            if(showArticles == null)
            {
                WhatArticlesSearch(articles);
            }
            else
            {
                foreach (var a in showArticles)
                {
                    a.Display();
                }
            }
        }
    }
}
