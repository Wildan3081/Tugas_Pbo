using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Sistem Manajemen Karyawan ===");
        Console.Write("Masukkan jenis karyawan (tetap/kontrak/magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan gaji pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        switch (jenis)
        {
            case "tetap":
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                break;
            case "magang":
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        Console.WriteLine("\n=== Data Karyawan ===");
        Console.WriteLine("Nama       : " + karyawan.GetNama());
        Console.WriteLine("ID         : " + karyawan.GetID());
        Console.WriteLine("Gaji Akhir : Rp" + karyawan.HitungGaji());
    }
}

public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public string GetNama() => nama;
    public void SetNama(string nama) => this.nama = nama;

    public string GetID() => id;
    public void SetID(string id) => this.id = id;

    public double GetGajiPokok() => gajiPokok;
    public void SetGajiPokok(double gajiPokok) => this.gajiPokok = gajiPokok;

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

public class KaryawanTetap : Karyawan
{
    private const double bonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GetGajiPokok() + bonusTetap;
    }
}

public class KaryawanKontrak : Karyawan
{
    private const double potonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GetGajiPokok() - potonganKontrak;
    }
}

public class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GetGajiPokok();
    }
}
