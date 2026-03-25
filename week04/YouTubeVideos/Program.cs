using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        List<Video> favouriteVideos = new List<Video>();

        Video video1 = new Video("Surviving 100 Days on Antarctica", "Mr. Beast", 240);
        video1.AddComment(new Comment("UserA", "Incredible!"));
        video1.AddComment(new Comment("UserB", "So cold."));
        video1.AddComment(new Comment("UserC", "Nice gear."));
        favouriteVideos.Add(video1);

        Video video2 = new Video("I Built a House Out of Legos", "BrickMaster", 600);
        video2.AddComment(new Comment("UserD", "Does it leak?"));
        video2.AddComment(new Comment("UserE", "My feet hurt looking at this."));
        video2.AddComment(new Comment("UserF", "Step on a brick!"));
        favouriteVideos.Add(video2);

        Video video3 = new Video("Tour my $15M Miami mansion with me", "faze", 570);
        video3.AddComment(new Comment("UserG", "Do you need a dog?"));
        video3.AddComment(new Comment("UserH", "$15M for this is insane."));
        video3.AddComment(new Comment("UserI", "why are all mansions today so monotone"));
        favouriteVideos.Add(video3);

        foreach (Video video in favouriteVideos)
        {
            video.Display();
            Console.WriteLine("------------------------------");
        }
    }
}