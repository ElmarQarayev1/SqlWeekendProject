

using System.Xml.Linq;
using SqlWeekendProject.Data;
using SqlWeekendProject.Model;

string opt;
do
{
    Console.WriteLine("1.Create speaker");
    Console.WriteLine("2.Get by id speaker");
    Console.WriteLine("3.All speakers");
    Console.WriteLine("4.Delete speaker");
    Console.WriteLine("5.Uptade speaker");
    Console.WriteLine("6.create Events");
    Console.WriteLine("7.All Events");
    Console.WriteLine("8.Get by id event");
    opt = Console.ReadLine();
    SpeakerDao speakerDao = new SpeakerDao();
    EventDao eventDao = new EventDao();
    List<int> speakerIds = new List<int>();
    switch (opt)
    { 
        case "1":
            AddSpeaker(speakerDao,speakerIds);
            break;
        case "2":
            GetSpeakerById(speakerDao);
            break;
        case "3":
            AllSpeakers(speakerDao);
            break;
        case "4":
            DeleteStudent(speakerDao);
            break;
        case "5":
            UpdateSpeaker(speakerDao);
            break;
        case "6":
            InsertEvents(eventDao,speakerIds);
            break;
        case "7":
            AllEvents(eventDao);
            break;
        case "8":
            GetEventById(eventDao);
            break;
        case "0":
            Console.WriteLine("Proqram bitdi!");
            break;
        default:
            Console.WriteLine("Wrong Option!");
            break;
    }
} while (opt!="0");

void AddSpeaker(SpeakerDao speakerDao,List<int> speakerIds)
{
    FullName:
    Console.WriteLine("enter fullname:");
    string fullname = Console.ReadLine();
    if (CheckString(fullname))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto FullName;
    }
    Position:
    Console.WriteLine("enter position:");
    string position = Console.ReadLine();
    if (CheckString(position))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Position;
    }
    Company:
    Console.WriteLine("enter company:");
    string company = Console.ReadLine();
    if (CheckString(company))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Company;
    }
    ImageUrl:
    Console.WriteLine("enter imageurl:");
    string imageurl = Console.ReadLine();
    if (CheckString(imageurl))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto ImageUrl;
    }
    Speaker speaker = new Speaker()
    {
        FullName = fullname,
        Position = position,
        Company = company,
        ImageUrl = imageurl

    };
    speakerDao.Insert(speaker);
    speakerIds.Add(speaker.ID);
}
void GetSpeakerById(SpeakerDao speakerDao)
{
    Id:
    Console.WriteLine("enter id:");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr,out id))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Id;

    }
    var data = speakerDao.GetSpeakerById(id);
    if (data == null) Console.WriteLine("student not found");
    else Console.WriteLine(data);

}
void AllSpeakers(SpeakerDao speakerDao)
{
    Console.WriteLine("All Students");
    foreach (var item in speakerDao.GetSpeakers())
    {
        Console.WriteLine(item);
    }

}
void DeleteStudent(SpeakerDao speakerDao)
{
    Sid:
    Console.WriteLine("enter id:");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Sid;

    }
    var data = speakerDao.GetSpeakerById(id);

    if (data == null) Console.WriteLine("student not found");
    else
    {
        speakerDao.Delete(id);
        Console.WriteLine("deleted student");
    }

}
 void UpdateSpeaker(SpeakerDao speakerDao)
{
    Id:
    Console.WriteLine("enter selected id:");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Id;

    }
    var data = speakerDao.GetSpeakerById(id);
    if (data == null) Console.WriteLine("student not found");
    else
    {
        Console.WriteLine("you change it: " + data);
        FullName:
        Console.WriteLine("enter new fullname:");
        string fullname = Console.ReadLine();
        if (CheckString(fullname))
        {
            Console.WriteLine("duzgun daxil edin!");

            goto  FullName;
        }
        Position:
        Console.WriteLine("enter new position:");
        string position = Console.ReadLine();
        if (CheckString(position))
        {
            Console.WriteLine("duzgun daxil edin!");

            goto Position;
        }
        Company:
        Console.WriteLine("enter new company:");
        string company = Console.ReadLine();
        if (CheckString(company))
        {
            Console.WriteLine("duzgun daxil edin!");

            goto Company;
        }
        ImageUrl:
        Console.WriteLine("enter new imageurl:");
        string imageurl = Console.ReadLine();
        if (CheckString(imageurl))
        {
            Console.WriteLine("duzgun daxil edin!");

            goto ImageUrl;
        }

        Speaker speaker = new Speaker()
        {
            ID = id,
            FullName = fullname,
            Position = position,
            Company = company,
            ImageUrl = imageurl
        };
        speakerDao.Update(speaker);
    }
}

void InsertEvents(EventDao eventDao,List<int> speakerIds)
{
    Name:
    Console.WriteLine(" add event name :");
    string name = Console.ReadLine();

    if (CheckString(name))
    {
        Console.WriteLine("duzgun daxil edin!");

        goto Name;
    }

    Desc:
    Console.WriteLine(" add description:");
    string description = Console.ReadLine();

    if (CheckString(description))
    {
        Console.WriteLine("duzgun daxil edin!");

        goto Desc;
    }
    Adress:
    Console.WriteLine(" add Adress :");
    string adress = Console.ReadLine();
    if (CheckString(adress))
    {
        Console.WriteLine("duzgun daxil edin!");

        goto Adress;
    }
     StartDate:
    Console.WriteLine(" add startdate ");
    string startdateStr = Console.ReadLine();
    DateTime startdate;
    if(!DateTime.TryParse(startdateStr,out startdate))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto StartDate;

    }
    StartTime:
    Console.WriteLine("add starttime");
    //TimeSpan starttime = TimeSpan.Parse(Console.ReadLine());
    string starttimeStr = Console.ReadLine();
    TimeSpan starttime;
    if(!TimeSpan.TryParse(starttimeStr,out starttime))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto StartTime;

    }
    EndTime:
    Console.WriteLine("add endtime");
    string  endtimeStr = Console.ReadLine();
    TimeSpan endtime;
    if (!TimeSpan.TryParse(endtimeStr, out endtime))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto EndTime;

    }

    Event event1 = new Event()
    {
        Name = name,
        Description = description,
        Address = adress,
        StartDate = startdate,
        StartTime = starttime,
        EndTime = endtime
    };
    eventDao.Insert(event1, speakerIds);
}
void AllEvents(EventDao eventDao)
{
    Console.WriteLine("all events");
    foreach (var item in eventDao.GetAllEvents())
    {
        Console.WriteLine(item);

    }
}
void GetEventById(EventDao eventDao)
{
    Id:
    Console.WriteLine("enter selected event id");
    string idStr = Console.ReadLine();
    int id;
    if (!int.TryParse(idStr, out id))
    {
        Console.WriteLine("duzgun daxil edin!");
        goto Id;
    }
    var data = eventDao.GetById(id);
    if (data == null) Console.WriteLine("event not found");
    else Console.WriteLine(data);
}
bool CheckString(string str)
{
    if (!String.IsNullOrWhiteSpace(str))
    {
        return false;
    }
    else return true;
}

Console.ReadLine();
