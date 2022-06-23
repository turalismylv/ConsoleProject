using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    class Pharmacy
    {
        public int Id { get; }
        public static int _id;
        public string Name { get; set; }

        public int MinSalary { get; set; }
        public double Budget { get; set; }
        public string Location { get; set; }
        public List<Employee> employees;
        public List<Drug> drugs;

        public Pharmacy(string name, int minsalary, double budget, string location)
        {
            Id = ++_id;
            Name = name;
            MinSalary = minsalary;
            Budget = budget;
            Location = location;
            employees = new List<Employee>();
            drugs = new List<Drug>();

        }
        public void AddEmplooye()
        {
            Helper.Print("Emplooye name daxil edin", ConsoleColor.Yellow);
            string ename = Console.ReadLine();
            Helper.Print("Emplooye surname daxil edin", ConsoleColor.Yellow);
            string sname = Console.ReadLine();
        dateTime:
            Helper.Print("Emplooye dogum tarixini qeyd edin: mm/dd/yyyy ", ConsoleColor.Yellow);
            string edate = Console.ReadLine();
            bool isDate = DateTime.TryParse(edate, out DateTime dateTime);
            if (!isDate)
            {
                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                goto dateTime;
            }
        esalary:
            Helper.Print("Emplooye salary qeyd edin ", ConsoleColor.Yellow);
            string esal = Console.ReadLine();
            bool IsSal = int.TryParse(esal, out int esalary);
            if (!IsSal)
            {
                Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                goto esalary;
            }
            if (esalary < MinSalary)
            {
                Helper.Print("Bu mebleg aptekin shertlerin odemir, zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto esalary;
            }
        eusername:
            Helper.Print("Emplooye username daxil edin", ConsoleColor.Yellow);
            string eusername = Console.ReadLine();
            foreach (var item1 in employees)
            {
                if (item1.Username == eusername)
                {
                    Helper.Print("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                    goto eusername;
                }
            }
        SETPASS:
            Helper.Print("Emplooye password daxil edin", ConsoleColor.Yellow);
            
            string password = Console.ReadLine();
            if (password.Length >= 5)
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMiniMaxChars = new Regex(@".{6,15}");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                if (!hasLowerChar.IsMatch(password))
                {
                    Helper.Print("Passwordda kicik herif yoxdur,zehmet olmasa yeniden daxil edin",ConsoleColor.Red);
                    goto SETPASS;
                }
                else if (!hasUpperChar.IsMatch(password))
                {
                    Helper.Print("Passwordda boyuk herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else if (!hasMiniMaxChars.IsMatch(password))
                {
                    Helper.Print("Passwordda uzunluqu 8~15 araliqinda deyil,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else if (!hasNumber.IsMatch(password))
                {
                    Helper.Print("Passwordda reqem yoxdur!,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }

                else if (!hasSymbols.IsMatch(password))
                {
                    Helper.Print("Passwordda xususi ishare yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else
                {
                    Helper.Print("Emplooye roletype qeyd edin: Admin/Staff? ", ConsoleColor.Yellow);
            string erole = Console.ReadLine();
            Employee employee1 = new Employee();
            employee1.Name = ename;
            employee1.Surname = sname;
            employee1.BirthDate = dateTime;
            employee1.Salary = esalary;
            employee1.Username = eusername;
            employee1.Password = password;
            if (erole.ToUpper() == "admin".ToUpper())
            {
                employee1.RoleType = RoleType.ADMIN;
            }
            else if (erole.ToUpper() == "staff".ToUpper())
            {
                employee1.RoleType = RoleType.STAFF;
            }

            Helper.Print($"{ename} adli emplooye yaradildi", ConsoleColor.Yellow);
            employees.Add(employee1);
                }
            }
            else
            {
                Helper.Print("Passwordda uzunluqu 5den azdir  ,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto SETPASS;
            }

           
        }
        public void AddDrug()
        {
            Drug drug = new Drug();
        name1:
            Helper.Print("Derman adini daxil edin", ConsoleColor.Yellow);
            string dname = Console.ReadLine();
            Helper.Print("Dermanin tipini qeyd edin: SYROB/POWDER/TABLET ?", ConsoleColor.Yellow);
            string dtype = Console.ReadLine();
            if (dtype.ToUpper() == "syrob".ToUpper())
            {
                drug.DrugType = DrugType.SYROB;
            }
            else if (dtype.ToUpper() == "powder".ToUpper())
            {
                drug.DrugType = DrugType.POWDER;
            }
            else if (dtype.ToUpper() == "tablet".ToUpper())
            {
                drug.DrugType = DrugType.TABLET;
            }
            foreach (var item2 in drugs)
            {
                if (item2.Name == dname && item2.DrugType == drug.DrugType)
                {
                    Helper.Print("Bu adli ve typl derman artiq movcuddur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);

                    goto name1;
                }
            }
        IsCount:
            Helper.Print("Dermanin sayini qeyd edin", ConsoleColor.Yellow);
            string dcoun = Console.ReadLine();
            bool IsCount = int.TryParse(dcoun, out int dcount);
            if (!IsCount)
            {
                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto IsCount;
            }
        purchase:
            Helper.Print("Dermanin alis qiymetini daxil edin", ConsoleColor.Yellow);
            string dpurch = Console.ReadLine();
            bool isPur = double.TryParse(dpurch, out double dpurprice);
            if (!isPur)
            {
                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto purchase;
            }
        saleprice:
            Helper.Print("Dermanin satis qiymetini daxil edin", ConsoleColor.Yellow);
            string dsal = Console.ReadLine();
            bool isSal = double.TryParse(dsal, out double saleprice); ;
            if (!isSal)
            {
                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto saleprice;
            }
            if (Budget < (dpurprice * dcount))
            {
                Helper.Print("Budceni kecdiyi ucun derman elave oluna bilmedi", ConsoleColor.Red);
                return;
            }
            drug.Name = dname;
            drug.Count = dcount;
            drug.PurchasePrice = dpurprice;
            drug.SalePrice = saleprice;
            drugs.Add(drug);
            Budget = Budget - (dpurprice * dcount);
            Helper.Print($"{dname} adli derman elave olundu", ConsoleColor.Green);
        }
        public void DeletDrug()
        {
            if (drugs.Count == 0)
            {
                Helper.Print("Hal hazirda bazada derman yoxdur maci<3", ConsoleColor.Red);
                return;
            }
            Helper.Print("Axtardiqiniz dermanin adini daxil edin:", ConsoleColor.Yellow);
            string search = Console.ReadLine();
            List<Drug> druge = drugs.FindAll(x => x.Name.ToUpper().Contains(search.ToUpper()));
            if (druge.Count == 0)
            {
                Helper.Print("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var item4 in druge)
            {

                Helper.Print($"{item4.Id} {item4.Name} {item4.DrugType}", ConsoleColor.Green);

            }
        did:
            Helper.Print("Silmek istediyiniz dermanin  ID qeyd edin", ConsoleColor.Yellow);
            string didd = Console.ReadLine();
            bool isId = int.TryParse(didd, out int did);
            if (!isId)
            {
                Helper.Print("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto did;
            }
            foreach (var item5 in drugs)
            {
                if (item5.Id == did)
                {
                    drugs.Remove(item5);
                    Budget = Budget + (item5.PurchasePrice * item5.Count);
                    Helper.Print($"{item5.Name} adli derman silindi twk", ConsoleColor.Blue);
                    break;
                }
            }
        }
        public void EditDrug()
        {
            if (drugs.Count == 0)
            {
                Helper.Print("Hal hazirda bazada derman yoxdur maci<3", ConsoleColor.Red);
                return;
            }
            Helper.Print("Editlemek istediyiniz dermanin adini daxil edin:", ConsoleColor.Yellow);
            string edit = Console.ReadLine();
            List<Drug> druge = drugs.FindAll(x => x.Name.ToUpper().Contains(edit.ToUpper()));
            if (druge.Count == 0)
            {
                Helper.Print("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var item4 in druge)
            {

                Helper.Print($"{item4.Id} {item4.Name} {item4.DrugType}", ConsoleColor.Green);

            }
        didd:
            Helper.Print("Editlemek istediyiniz dermanin  ID qeyd edin", ConsoleColor.Yellow);
            string ddid = Console.ReadLine();
            bool isIdd = int.TryParse(ddid, out int _did);
            if (!isIdd)
            {
                Helper.Print("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto didd;
            }
            foreach (var item6 in drugs)
            {
                double oldpursh = item6.PurchasePrice;
                int count = item6.Count;
                DrugType dt = item6.DrugType;
                if (item6.Id == _did)
                {
                newdrug:
                    Helper.Print("Derman yeni adini daxil edin", ConsoleColor.Yellow);
                    string dnname = Console.ReadLine();

                IsnCount:
                    Helper.Print("Dermanin sayini qeyd edin", ConsoleColor.Yellow);
                    string dncoun = Console.ReadLine();
                    bool IsnCount = int.TryParse(dncoun, out int dncount);
                    if (!IsnCount)
                    {
                        Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto IsnCount;
                    }
                npurchase:
                    Helper.Print("Dermanin alis qiymetini daxil edin", ConsoleColor.Yellow);
                    string dnpurch = Console.ReadLine();
                    bool isnPur = double.TryParse(dnpurch, out double dnpurprice);
                    if (!isnPur)
                    {
                        Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto npurchase;
                    }
                nsaleprice:
                    Helper.Print("Dermanin satis qiymetini daxil edin", ConsoleColor.Yellow);
                    string dnsal = Console.ReadLine();
                    bool isnSal = double.TryParse(dnsal, out double nsaleprice);
                    if (!isnSal)
                    {
                        Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto nsaleprice;
                    }
                    if (Budget < (dnpurprice * dncount))
                    {
                        Helper.Print("Budceni kecdiyi ucun derman elave oluna bilmedi", ConsoleColor.Red);
                        return;

                    }
                    Helper.Print("Dermanin yeni tipini qeyd edin: SYROB/POWDER/TABLET ?", ConsoleColor.Yellow);
                    string dntype = Console.ReadLine();
                    if (dntype.ToUpper() == "syrob".ToUpper())
                    {
                        item6.DrugType = DrugType.SYROB;
                    }
                    else if (dntype.ToUpper() == "powder".ToUpper())
                    {
                        item6.DrugType = DrugType.POWDER;
                    }
                    else if (dntype.ToUpper() == "tablet".ToUpper())
                    {
                        item6.DrugType = DrugType.TABLET;
                    }

                    if (dt == item6.DrugType)
                    {
                        Helper.Print("Bu adli ve typl derman artiq movcuddur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto newdrug;
                    }

                    item6.Name = dnname;
                    item6.Count = dncount;
                    item6.PurchasePrice = dnpurprice;
                    item6.SalePrice = nsaleprice;
                    Budget = Budget + (oldpursh * count) - (dnpurprice * dncount);
                    Helper.Print($"{item6.Name} addli derman editlendi twk<3", ConsoleColor.Blue);
                }
            }
        }
        public void DeletEmploye()
        {

            Helper.Print("Silmek istediyiniz emplooye adini qeyd edin", ConsoleColor.Yellow);
            string dem = Console.ReadLine();
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(dem.ToUpper()));
            if (emp.Count == 0)
            {
                Helper.Print("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var em in emp)
            {
                Helper.Print($"{em.Id} {em.Name} {em.RoleType}", ConsoleColor.Green);
            }
        _did:
            Helper.Print("Silmek istediyiniz emplooye  ID qeyd edin", ConsoleColor.Yellow);
            string ddidd = Console.ReadLine();
            bool isId_ = int.TryParse(ddidd, out int _didd);
            if (!isId_)
            {
                Helper.Print("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto _did;
            }
            foreach (var item5 in employees)
            {
                if (item5.Id == _didd)
                {
                    employees.Remove(item5);

                    Helper.Print($"{item5.Name} adli emplooye silindi twk", ConsoleColor.Blue);
                    break;
                }
            }
        }
        public void EditEmploye()
        {
            if (employees.Count == 0)
            {
                Helper.Print("Hal hazirda bazada emplooye yoxdur maci<3", ConsoleColor.Red);
                return;
            }
            Helper.Print("Editlemel istediyiniz emplooye adini qeyd edin", ConsoleColor.Yellow);
            string edem = Console.ReadLine();
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(edem.ToUpper()));
            if (emp.Count == 0)
            {
                Helper.Print("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var em in emp)
            {
                Helper.Print($"{em.Id} {em.Name} {em.RoleType}", ConsoleColor.Green);
            }
        delid:
            Helper.Print("Silmek istediyiniz emplooye  ID qeyd edin", ConsoleColor.Yellow);
            string delem = Console.ReadLine();
            bool isDel = int.TryParse(delem, out int delid);
            if (!isDel)
            {
                Helper.Print("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto delid;
                ;
            }
            foreach (var item5 in employees)
            {
                if (item5.Id == delid)
                {
                    Helper.Print("Yeni ad daxil edin", ConsoleColor.Yellow);
                    string newem = Console.ReadLine();
                    Helper.Print("Yeni soyad daxil edin", ConsoleColor.Yellow);
                    string newsem = Console.ReadLine();
                dateTimee:
                    Helper.Print("Emplooyenin yeni dogum tarixini qeyd edin: mm/dd/yyyy ", ConsoleColor.Yellow);
                    string endate = Console.ReadLine();
                    bool isnDate = DateTime.TryParse(endate, out DateTime ndateTime);
                    if (!isnDate)
                    {
                        Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                        goto dateTimee;
                    }
                nesalary:
                    Helper.Print("Emplooyenin yeni salary qeyd edin ", ConsoleColor.Yellow);
                    string nesal = Console.ReadLine();
                    bool IsnSal = int.TryParse(nesal, out int nesalary);
                    if (!IsnSal)
                    {
                        Helper.Print("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                        goto nesalary;
                    }
                    if (nesalary < MinSalary)
                    {
                        Helper.Print("Bu mebleg aptekin shertlerin odemir, zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto nesalary;
                    }
                neusername:
                    Helper.Print("Emplooye username daxil edin", ConsoleColor.Yellow);
                    string neusername = Console.ReadLine();
                    foreach (var item1 in employees)
                    {
                        if (item1.Username == neusername)
                        {
                            Helper.Print("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
                            goto neusername;
                        }
                    }
                   
                SETPASS:
                    Helper.Print("Emplooye password daxil edin", ConsoleColor.Yellow);

                    string password = Console.ReadLine();
                    if (password.Length >= 5)
                    {
                        var hasNumber = new Regex(@"[0-9]+");
                        var hasUpperChar = new Regex(@"[A-Z]+");
                        var hasMiniMaxChars = new Regex(@".{6,15}");
                        var hasLowerChar = new Regex(@"[a-z]+");
                        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                        if (!hasLowerChar.IsMatch(password))
                        {
                            Helper.Print("Passwordda kicik herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else if (!hasUpperChar.IsMatch(password))
                        {
                            Helper.Print("Passwordda boyuk herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else if (!hasMiniMaxChars.IsMatch(password))
                        {
                            Helper.Print("Passwordda uzunluqu 8~15 araliqinda deyil,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else if (!hasNumber.IsMatch(password))
                        {
                            Helper.Print("Passwordda reqem yoxdur!,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }

                        else if (!hasSymbols.IsMatch(password))
                        {
                            Helper.Print("Passwordda xususi ishare yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else
                        {
                            Helper.Print("Emplooye roletype qeyd edin: Admin/Staff? ", ConsoleColor.Yellow);
                            string nerole = Console.ReadLine();
                            if (nerole.ToUpper() == "admin".ToUpper())
                            {
                                item5.RoleType = RoleType.ADMIN;
                            }
                            else if (nerole.ToUpper() == "staff".ToUpper())
                            {
                                item5.RoleType = RoleType.STAFF;
                            }
                            item5.Name = newem;
                            item5.Surname = newsem;
                            item5.BirthDate = ndateTime;
                            item5.Salary = nesalary;
                            item5.Username = neusername;
                            item5.Password = password;
                            Helper.Print($"{item5.Name} adli isci editlendi twk<3", ConsoleColor.Blue);
                        }
                    }
                    else
                    {
                        Helper.Print("Passwordda uzunluqu 5den azdir  ,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto SETPASS;
                    }
                }
            }
        }
        public void Seel()
        {
            if (drugs.Count == 0)
            {
                Helper.Print("Bazada derman yoxdu !!", ConsoleColor.Red);
                return;
            }
            Helper.Print("Derman adi daxil edin", ConsoleColor.DarkYellow);
            string dad = Console.ReadLine();
            Helper.Print("Derman tipini qeyd edin: syrob/powder/tablet?", ConsoleColor.DarkYellow);
            string dyit = Console.ReadLine();
        dsay:
            Helper.Print("Sayini daxil edin", ConsoleColor.DarkYellow);
            string dsay = Console.ReadLine();
            bool isSay = int.TryParse(dsay, out int ddsay);
            if (!isSay)
            {
                Helper.Print("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.DarkRed);
                goto dsay;
            }

            List<Drug> drugess = drugs.FindAll(x => x.Name.ToUpper().Contains(dad.ToUpper()) && x.DrugType.ToString().ToUpper().Contains(dyit.ToUpper())/*&&x.Count>=ddsay*/);
            if (drugess.Count == 0)
            {
                Helper.Print("Qalmayib", ConsoleColor.Red);
                return;
            }
            foreach (var druge in drugess)
            {
                if (druge.Count == 0)
                {
                    Helper.Print("Qalmayib", ConsoleColor.Red);
                    return;
                }
                if (druge.Count < ddsay)
                {
                    Helper.Print($"Qeyd etdiyiniz qeder yoxdur,{druge.Count} bu qeder derman var isteyirsinizmi?: yes/no", ConsoleColor.Blue);
                    string yesno2 = Console.ReadLine();
                    if (yesno2.ToUpper() == "yes".ToUpper())
                    {
                        druge.Count = druge.Count - druge.Count;
                        Budget = Budget + (druge.SalePrice * druge.Count);
                        Helper.Print($"{druge.Name} adli derman satildi maci<3", ConsoleColor.Blue);
                        return;
                    }
                    else if (yesno2.ToUpper() == "no".ToUpper())
                    {
                        return;
                    }
                }
                Helper.Print($"ID:{druge.Id} AD:{druge.Name} Say:{druge.Count} Tip:{druge.DrugType} SAtis qiymeti:{druge.SalePrice}", ConsoleColor.Yellow);
                Helper.Print("Satis etmek istediynize eminsinizmi: yes/no?", ConsoleColor.Green);
                string yesno = Console.ReadLine();
                if (yesno.ToUpper() == "yes".ToUpper())
                {
                    druge.Count = druge.Count - ddsay;
                    Budget = Budget + (druge.SalePrice * ddsay);
                    Helper.Print($"{druge.Name} adli derman {ddsay} eded satildi maci<3", ConsoleColor.Blue);
                }
            }
        }

    }

}


