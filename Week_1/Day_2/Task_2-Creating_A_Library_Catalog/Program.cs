﻿using System;
using books_component;
using library_component;
using mediaitems_component;

namespace Main_Program{
    public class Program{
        public static void Main(string[] args){
            // Instatiate library object
            Library library = new ("A2SV Library", "Beverly Hills, Palo Alto", [], []);

            Console.WriteLine("Hello there! Welcome to the A2SV Library!\n---------------------------------");
            Console.WriteLine("What would you like to do in the library today? Select from below:\n");
            Console.WriteLine("0 - Just run the sample testcases");
            Console.WriteLine("1 - Add a book to the library");
            Console.WriteLine("2 - Add a media item to the library");
            Console.WriteLine("3 - View entire catalog of library");
            Console.WriteLine("4 - Clear all books from library");
            Console.WriteLine("5 - Clear all media items from library");

            int ans = ReadNumber("\nYour input: ", 0, 5);
            Console.WriteLine();
            
            switch(ans){
                case 0:
                    // Available books to be added to library
                    List<Book> books = [
                        new Book("DSA Made Simple", "Farouk U. Sedick", "9780316769488", 2026),
                        new Book("Biography of the Great Farouk", "Mohammed N. Haqq", "9780061120084", 2027),
                        new Book("Why Ghana is Better Than Ethiopia", "Surafel & Matiows", "9780451524935", 2025)
                    ];

                    // Adding books to library
                    foreach(Book book in books){
                        library.AddBook(book);
                    }

                    // Available media items to be added to library
                    List<MediaItem> mediaItems = [
                        new MediaItem("How I Built The Next Google", "Audio", 2),
                        new MediaItem("24 hours of Kudus explaining", "Audio", 24),
                        new MediaItem("A2SV Leaks", "Video", 4)
                    ];

                    // Adding books to library
                    foreach(MediaItem item in mediaItems){
                        library.AddMediaItem(item);
                    }

                    // Displaying catalog of library
                    library.PrintCatalog();
                    break;

                case 1:
                    Console.WriteLine("Please provide the title, author, isbn and publication year of book below (separate with space):");
                    List<string> details = [.. Console.ReadLine().Split()];
                    int yr;
                    // Error checking and handling to prevent invalid input
                    // Input should contain 4 different infos, year should be an integer and should be >=1000 but <= 3000  
                    if (details.Count != 4 || !int.TryParse(details[3], out yr) || yr <= 1000 || yr >= 3000){
                        Console.WriteLine("You provided an invalid input\n");
                        break;
                    }
                    library.AddBook(new Book(details[0], details[1], details[2], yr));
                    Console.WriteLine($"{details[0]} added to books in library.");
                    break;

                case 2:
                    Console.WriteLine("Please provide the title, media type and duration of media below (separate with space):");
                    List<string> detail = [.. Console.ReadLine().Split()];
                    int dur;
                    // Error checking and handling to prevent invalid input
                    // Input should contain 3 different infos, duration should be an integer and should be > 0 
                    if (detail.Count != 3 || !int.TryParse(detail[2], out dur) || dur < 0){
                        Console.WriteLine("You provided an invalid input\n");
                        break;
                    }
                    library.AddMediaItem(new MediaItem(detail[0], detail[1], Convert.ToInt32(detail[2])));
                    Console.WriteLine($"{detail[0]} added to media items in library.");
                    break;

                case 3:
                    library.PrintCatalog();
                    break;

                case 4:
                    // Clearing all books
                    foreach (Book book in library.Books){
                        library.RemoveBook(book);
                    }
                    Console.WriteLine("All books cleared!");
                    break;

                case 5:
                    // Clearing all media items
                    foreach (MediaItem item in library.MediaItems){
                        library.RemoveMediaItem(item);
                    }
                    Console.WriteLine("All media items cleared!");
                    break;

                default:
                    Console.WriteLine("\nThanks for spending time in the library. Have a wonderful day!\n");
                    break;
            }
        }
   
        // Function to handle reading of input integers
        public static int ReadNumber(string msg, int lower, int upper){
            int res = 0;
            string? val = "";
            bool start = false;

            do{
                if (start)
                    Console.WriteLine($"\nPlease enter a number between {lower} and {upper} inclusive!\n");

                Console.Write(msg);
                val = Console.ReadLine();
                start = true;
           } while (!int.TryParse(val, out res) || res<lower || res>upper); // if input is not an integer or is out of bounds, ask for input again

            return res;
        }
    }
}