using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Lab_10
{
    class Program
    {
        static void Main(string[] args)      
     
        {
            List<Movie> movieList = new List<Movie>();
            // Add movies to MovieList
            movieList.Add(new Movie("Howl's Moving Castle", "animated"));
            movieList.Add(new Movie("A Scanner Darkly", "animated"));
            movieList.Add(new Movie("Witchfinder General", "horror"));
            movieList.Add(new Movie("VVitch", "horror"));
            movieList.Add(new Movie("Krull", "scifi"));
            movieList.Add(new Movie("Spaceballs", "scifi"));
            movieList.Add(new Movie("American Astronaut", "scifi"));
            movieList.Add(new Movie("The Treasure of the Sierra Madre", "drama"));
            movieList.Add(new Movie("Diary of a Country Priest", "drama"));
            movieList.Add(new Movie("Lancelot du Lac", "drama"));

            do
                RecommendMovies(movieList);
            while (WillContinue());
        }
        

        public static bool WillContinue()
        {
            Console.Write("Would you like to continue (y/n)? "); // prompt user to continue or exit

            if (Console.ReadLine().ToLower() == "y") // user input to continue or exit
            {
                return true;
            }

            else
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
        }
        public static void RecommendMovies(List<Movie> movieList)
        {
            Console.Write($"***************************************************\n " +
                $"1 = animated | 2 = horror | 3 = scifi | 4 = drama\n" +
                $"***************************************************\n" +
                $"Please select a category: ");
            string inputNumber = Console.ReadLine();
            string userCategory = inputNumber switch
            {
                "1" => "animated",
                "2" => "horror",
                "3" => "scifi",
                "4" => "drama",
                _ => null,
            };

            if (movieList.Any(m => m.Category == userCategory))  // Validate input
            {
                // Make new Sublist of selected selected category, sort alpha
                List<Movie> SubList = new List<Movie>((movieList.Where(m => m.Category == userCategory)).OrderBy(m => m.Title));
                Console.WriteLine($"Here is a list of all {userCategory} movies in the database: ");
                foreach (Movie movie in SubList)  // Iterate over each movie in selected category
                {
                    Console.WriteLine(movie.Title);
                }
            }
            else
            {
                Console.WriteLine("That is not a valid category");
            }
        }


    }


}
