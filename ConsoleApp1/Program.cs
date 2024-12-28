
using System;


public class NewsArticel
{
    public string Title { get; }
    public string Content { get;  }

    public NewsArticel(string titel , string content)
    {
        this.Title = titel;
        this.Content = content;
    }
}

public class NewsPublisher
{
    public event EventHandler<NewsArticel> NewNewsPublished;

    public void PublishNews(string title, string content)
    {
        var Articel = new NewsArticel(title, content);
        OnNewNewsPublished(Articel);
    }

    protected virtual void OnNewNewsPublished(NewsArticel Articel)
    {
        NewNewsPublished?.Invoke(this, Articel);
    }
}

public class NewsSubscriber
{
    private string Name { get; }
    public NewsSubscriber(string name)
    {
        this.Name = name;
    }
    public void Subscribe(NewsPublisher newsPublisher)
    {
        newsPublisher.NewNewsPublished += HandleNewNews;
    }

    public void UnSubscribe(NewsPublisher newsPublisher)
    {
        newsPublisher.NewNewsPublished -= HandleNewNews;
    }
    private void HandleNewNews(object sender, NewsArticel Articel)
    {
        Console.WriteLine($"{Name} received a new News articel");
        Console.WriteLine($"Titel: {Articel.Title}");
        Console.WriteLine($"Content: {Articel.Content}");
        Console.WriteLine();
    }
}
public class Program
{
    static void Main(string[] args)
    {

        NewsPublisher publischer = new NewsPublisher(); ;

        NewsSubscriber subscriber1 = new NewsSubscriber("Subscriber 1");
        subscriber1.Subscribe(publischer);

        NewsSubscriber subscriber2 = new NewsSubscriber("Subsciber 2");
        subscriber2.Subscribe(publischer);


        publischer.PublishNews("Hallo Khaled", "Heute gib es neue Nachricht für dich");
        publischer.PublishNews("Hallo Khadijah", "Wir haben heute eine Fulg nach Beirut gebucht");
        publischer.PublishNews("Hallo Marah", "Marah will mit uns fliegen");

        subscriber1.UnSubscribe(publischer);

        publischer.PublishNews("Hallo Hamssa", "Du fliegst auch mit");

        subscriber2.UnSubscribe(publischer);

        publischer.PublishNews("Hallo Bailassan", "Du kommst natürlch auch mit");

        subscriber1.Subscribe(publischer);
        publischer.PublishNews("Hallo World", "Goot sei Dank jede Seconde");

      //  subscriber1.UnSubscribe(publischer);

        publischer.PublishNews("Hallo Khaled", "Heute gib es neue Nachricht für dich");
        publischer.PublishNews("Hallo Khadijah", "Wir haben heute eine Fulg nach Beirut gebucht");
        publischer.PublishNews("Hallo Marah", "Marah will mit uns fliegen");

        Console.ReadKey();
    }

    
}


