using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerInC_
{
    public class MusicPlayer
    {
            private List<string> playlist = new List<string>();

            public void Play()
            {
                while (true)
                {
                    DisplayMenu();

                    Console.Write("Enter your music app: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddMusic();
                            break;
                        case 2:
                            EditMusic();
                            break;
                        case 3:
                            PlayMusic();
                            break;
                        case 4:
                            DeleteMusic();
                            break;
                        case 5:
                            ShufflePlaylist();
                            break;
                        case 6:
                            SortPlaylist();
                            break;
                        case 7:
                            DisplayPlaylist();
                            break;
                        case 8:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            private void DisplayMenu()
            {
                Console.WriteLine("1. Add Music to Playlist");
                Console.WriteLine("2. Edit Music");
                Console.WriteLine("3. Play Music");
                Console.WriteLine("4. Delete Music");
                Console.WriteLine("5. Shuffle Playlist");
                Console.WriteLine("6. Sort Playlist");
                Console.WriteLine("7. Display Playlist");
                Console.WriteLine("8. Exit");
            }

            private void AddMusic()
            {
                Console.Write("Enter the name of the music: ");
                string musicName = Console.ReadLine();
                playlist.Add(musicName);
                Console.WriteLine($"{musicName} added to the playlist.");
            }

            private void EditMusic()
            {
                DisplayPlaylist();
                Console.Write("Enter the index of the music to edit: ");
                int index = int.Parse(Console.ReadLine());

                if (IsValidIndex(index))
                {
                    Console.Write("Enter the new name of the music: ");
                    string newMusicName = Console.ReadLine();
                    playlist[index] = newMusicName;
                    Console.WriteLine("Music edited successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
            }

            private void PlayMusic()
            {
                DisplayPlaylist();
                Console.Write("Enter the index of the music to play: ");
                int index = int.Parse(Console.ReadLine());

                if (IsValidIndex(index))
                {
                    Console.WriteLine($"Playing {playlist[index]}.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
            }

            private void DeleteMusic()
            {
                DisplayPlaylist();
                Console.Write("Enter the index of the music to delete: ");
                int index = int.Parse(Console.ReadLine());

                if (IsValidIndex(index))
                {
                    string deletedMusic = playlist[index];
                    playlist.RemoveAt(index);
                    Console.WriteLine($"{deletedMusic} deleted from the playlist.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
            }

            private void ShufflePlaylist()
            {
                Random rand = new Random();
                playlist = playlist.OrderBy(x => rand.Next()).ToList();
                Console.WriteLine("Playlist shuffled.");
            }

            private void SortPlaylist()
            {
                playlist.Sort();
                Console.WriteLine("Playlist sorted.");
            }

            private void DisplayPlaylist()
            {
                Console.WriteLine("Playlist:");
                for (int i = 0; i < playlist.Count; i++)
                {
                    Console.WriteLine($"{i}. {playlist[i]}");
                }
            }

            private bool IsValidIndex(int index)
            {
                return index >= 0 && index < playlist.Count;
            }
        }
}
