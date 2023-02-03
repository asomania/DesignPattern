/*//singleton
public class singletonFinal
{
    private static singletonFinal nesne;
    public static Object obje = new Object();
    private singletonFinal() { }

    public static singletonFinal SingletonOlustur()
    {
        if (nesne == null)
        {
            lock (obje)
            {
                if (nesne == null)
                {
                    nesne = new singletonFinal();
                }
            }
        }

        return nesne;
    }
}
*/

/*//Abstract fac
public abstract class ram
{
    public abstract void ramHiz();
}

public abstract class islemci
{
    public abstract void islemciHiz();
}

public class asusRam : ram
{
    public override void ramHiz()
    {
        Console.WriteLine("ram hiz 44000");
    }
}
public class corsairRam : ram
{
    public override void ramHiz()
    {
        Console.WriteLine("ram hiz 41231200");
    }
}

public class asusIslemci : islemci
{
    public override void islemciHiz()
    {
        Console.WriteLine("islemci hiz 44000");
    }
}
public class corsairIslemci : islemci
{
    public override void islemciHiz()
    {
        Console.WriteLine("islemci hiz 333300");
    }
}

public abstract class PcFactory
{
    public abstract ram ramTopla();
    public abstract islemci islemciTopla();
}

public class AsusPcFab : PcFactory
{
    public override islemci islemciTopla()
    {
        return new asusIslemci();
    }
    public override ram ramTopla()
    {
        return new asusRam();
    }
}

public class CorsairPcFab : PcFactory
{
    public override islemci islemciTopla()
    {
        return new corsairIslemci();
    }

    public override ram ramTopla()
    {
        return new corsairRam();
    }
}

public class Factory
{
    public ram _ram;
    public islemci _islemci;
    public PcFactory _PcFactory;

    public Factory (PcFactory pcFactory1)
    {
        _islemci = pcFactory1.islemciTopla();
        _ram = pcFactory1.ramTopla();
    }
    public void yazdir()
    {
        _islemci.islemciHiz();
        _ram.ramHiz();
    }
}
*/

/*//builder



public class lesson
{
    public int id;
    public string name;
    public int price;
    public int discountedPrice;
}

public abstract class lessonBuilder
{
    public lesson _lesson;

    public abstract void GetLesson();
    public abstract void applyDiscount();
    public abstract lesson getResult();
}

public class newStudentLessonBuilder : lessonBuilder
{ 
    public override void GetLesson()
    {
        _lesson = new lesson();
        _lesson.id = 1;
        _lesson.name = "dene";
        _lesson.price = 1;
    }

    public override void applyDiscount()
    {
       _lesson.discountedPrice=_lesson.price*1/2;
    }

    public override lesson getResult()
    {
        return _lesson;
    }
}

public class LessonDirector
{
    private lessonBuilder lessonBuilder1;

    public LessonDirector(lessonBuilder c)
    {
        this.lessonBuilder1 = c;
    }
    public void make()
    {
        lessonBuilder1.GetLesson();
        lessonBuilder1.applyDiscount();
    }
}

class Program
{
    public static void main()
    {
        lessonBuilder lesson= new newStudentLessonBuilder();

        LessonDirector lesDir = new LessonDirector(lesson); 
        lesDir.make();

        lesson lesSon = lesson.getResult();

        Console.WriteLine(lesSon.name);
    }
}
*/

/* //facade


public class motorates
{
    public void motorFire()
    {
        Console.WriteLine("motor ateslendi");
    }

    public void motorDurdur()
    {
        Console.WriteLine("Motor durduruldu");
    }
}

public class arabaGitti
{
    public int vites;
    public void arabaGo() {
        if (vites == 0) Console.WriteLine("araba gitmedi");
        else Console.WriteLine("araba haraket etti");

    }
}

public class facade
{
    public motorates _motorates = new motorates();
    public arabaGitti _araba = new arabaGitti();

    public facade(int vites)
    {
        _araba.vites=vites;
    }

    public void Run()
    {
        _motorates.motorFire();
        _araba.arabaGo();
    }
    public void Stop()
    {
        _motorates.motorDurdur();
    }
}
*/

/* //adapter
public interface IYazdir
{
    public void yazdir();
}


public class yazici : IYazdir
{
    public void yazdir()
    {
        Console.WriteLine("yazici ile yazdirildi ");
    }
}

public class faks
{
    public void faksYazdir()
    {
        Console.WriteLine("Faks ile yazdirildi");
    }
}

public class faksAdapter : IYazdir
{
    faks _faks = new faks();
    public void yazdir()
    {
        _faks.faksYazdir();
    }
}

class Program {

    public static void Main(string[] args)
    {
        IYazdir _new = new faksAdapter();

        _new.yazdir();
    }
}
*/

/*//bridge


public interface IReportFormat
{
    public void format();
}

public class WebFormat : IReportFormat
{
    public void format()
    {
        Console.WriteLine("Web Formatinda");
    }
}

public class MasaustuFormat : IReportFormat
{
    public void format()
    {
        Console.WriteLine("Masaustu Formatinda");
    }
}

public  class Report
{
    public IReportFormat _report;

    public Report (IReportFormat report)
    {
        _report = report;
    }

    public virtual void report() { 
    _report.format();
    }
}

public class satis : Report
{
    public satis(IReportFormat report):base(report)
    {
        _report= report;
    }

    public override void report()
    {
        _report.format();
    }
}

public class calisan : Report
{
    public calisan(IReportFormat report):base(report)
    {
        _report= report;
    }
    public override void report()
    {
       _report.format();
    }
}
*/

/* //compozite
public interface ISIrketElemani
{
    String yazdir();
}

public class BireyselEleman : ISIrketElemani
{
    string adi;
    public BireyselEleman(string adi)
    {
        this.adi = adi;
    }
    public string yazdir()
    {
        return adi;
    }
}

public class Departman : ISIrketElemani
{
    string adi;
    List<ISIrketElemani> elemanlar;

    public Departman (string ad)
    {
        this.adi = ad;
        elemanlar = new List<ISIrketElemani>();
    }

    
    public void ekle(ISIrketElemani isim)
    {
        elemanlar.Add(isim);
    }
    public void sil(ISIrketElemani isim)
    {
        elemanlar.Remove(isim);
    }
    public string yazdir()
    {
        foreach (ISIrketElemani elaman in elemanlar)
        {
            elaman.yazdir();
        }
        return adi;

    }
}

class Program
{
    public static void main()
    {
        ISIrketElemani elemani= new BireyselEleman("ali");
        ISIrketElemani elemani1= new BireyselEleman("veli");

        ISIrketElemani departman = new Departman("Muhasebe");

        departman.ekle(elemani);
    }
}
*/

/*//visitor


public abstract class Tablet
{
    public abstract void accept(Ivisitor _visitor);
}

public class IPad : Tablet
{
    public override void accept(Ivisitor _visitor)
    {
        _visitor.visit(this);
    }
}
public class Galaxy : Tablet
{
    public override void accept(Ivisitor _visitor)
    {
        _visitor.visit(this);
    }
}
public class levovo : Tablet
{
    public override void accept(Ivisitor _visitor)
    {
        _visitor.visit(this);
    }
}


public interface Ivisitor
{
    void visit(Tablet tablet);
}

public class ThereG : Ivisitor
{
    public void visit(Tablet tablet)
    {
        if (tablet is IPad)
        {
            Console.WriteLine("3G acildi");
        }
        else if (tablet is Galaxy) {
            Console.WriteLine("3G acilmadi");
        }
    }
}
public class Wifi : Ivisitor
{
    public void visit(Tablet tablet)
    {
        if (tablet is IPad)
        {
            Console.WriteLine("wifi acildi");
        }
        else if (tablet is Galaxy)
        {
            Console.WriteLine("wifi acilmadi");
        }
    }
}

class Program
{
    public static void Main()
    {
        Tablet new1 = new IPad();
        
        new1.accept(new ThereG());
        new1.accept(new Wifi());
    }
}
*/

/* //strateji
 * interface Strateji
{
    void IUSec(IUDuzen uDuzen);
    void kampanyeSec(IKampanya kampanya);
    void cagir();
}
class Program
{
    static void main()
    {
        IKampanya kk = new Yılbasi_kampanyasi();
        IUDuzen uu = new Yilbasi();

        yilbasi_Stratejisi yy = new yilbasi_Stratejisi();

        yy.kampanyeSec(kk);
        yy.IUSec(uu);
        yy.cagir();
    }
}

class yilbasi_Stratejisi : Strateji
{
    private IKampanya k;
    private IUDuzen IU;
    public void IUSec(IUDuzen uDuzen)
    {
        IU = uDuzen;
    }

    public void kampanyeSec(IKampanya kampanya)
    {
        k = kampanya;
    }
    public void cagir()
    {
        int kampanyaOran = k.Kampanya();
        Console.WriteLine(kampanyaOran);
        IU.goster();


    }
}

interface IUDuzen
{
    void goster();
}

class Yilbasi : IUDuzen
{
    public void goster()
    {
        Console.WriteLine("Yılbasi duzeni gosteriiliyor");
    }
}
class HatfaSonu : IUDuzen
{
    public void goster()
    {
        Console.WriteLine("haftasonu duzeni gosteriiliyor");
    }
}
class Haftaİci : IUDuzen
{
    public void goster()
    {
        Console.WriteLine("haftaici duzeni gosteriiliyor");
    }
}

interface IKampanya
{
    public int Kampanya();
}

class Yılbasi_kampanyasi : IKampanya
{
    public int Kampanya()
    {
        return 25;
    }
}
class Haftaici_kampanyasi : IKampanya
{
    public int Kampanya()
    {
        return 10;
    }
}
class HAftasonu_Kampanya : IKampanya
{
    public int Kampanya()
    {
        return 15;
    }
}
 */