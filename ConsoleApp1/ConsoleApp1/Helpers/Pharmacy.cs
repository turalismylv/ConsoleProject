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
                Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                goto dateTime;
            }
            esalary:
            Helper.Print("Emplooye salary qeyd edin ", ConsoleColor.Yellow);
            string esal = Console.ReadLine();
            bool IsSal = int.TryParse(esal, out int esalary);
            if (!IsSal)
            {
                Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                goto esalary;
            }
            if (esalary < MinSalary)
            {
                Helper.Printslow($"Bu mebleg aptekin shertlerin odemir: Minimum: {MinSalary}, zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto esalary;
            }
            eusername:
            Helper.Print("Emplooye username daxil edin", ConsoleColor.Yellow);
            string eusername = Console.ReadLine();
            foreach (var item1 in employees)
            {
                if (item1.Username == eusername)
                {
                    Helper.Printslow("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
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
                    Helper.Printslow("Passwordda kicik herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else if (!hasUpperChar.IsMatch(password))
                {
                    Helper.Printslow("Passwordda boyuk herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else if (!hasMiniMaxChars.IsMatch(password))
                {
                    Helper.Printslow("Passwordda uzunluqu 6~15 araliqinda deyil,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else if (!hasNumber.IsMatch(password))
                {
                    Helper.Printslow("Passwordda reqem yoxdur!,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }

                else if (!hasSymbols.IsMatch(password))
                {
                    Helper.Printslow("Passwordda xususi ishare yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto SETPASS;
                }
                else
                {
                    roleType:
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
                    else
                    {
                        Helper.Printslow("Yanlis daxil edildi,Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto roleType;
                    }
                    Console.Clear();
                    Helper.Printslow($"{ename.ToUpper()} adli emplooye yaradildi", ConsoleColor.Yellow);
                    employees.Add(employee1);
                }
            }
            else
            {
                Helper.Printslow("Passwordda uzunluqu 5den azdir  ,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto SETPASS;
            }


        }
        public void AddDrug()
        {
            Drug drug = new Drug();
            name1:
            Helper.Print("Derman adini daxil edin", ConsoleColor.Yellow);
            string dname = Console.ReadLine();
            drugtype:
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
            else
            {
                Helper.Printslow("Yanlis daxil edildi,Yeniden duzgun daxil et", ConsoleColor.Red);
                goto drugtype;
            }

            foreach (var item2 in drugs)
            {
                if (item2.Name == dname && item2.DrugType == drug.DrugType)
                {
                    Helper.Printslow("Bu adli ve typl derman artiq movcuddur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                    goto name1;
                }
            }
            IsCount:
            Helper.Print("Dermanin sayini qeyd edin", ConsoleColor.Yellow);
            string dcoun = Console.ReadLine();
            bool IsCount = int.TryParse(dcoun, out int dcount);
            if (dcount<=0)
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto IsCount;
            }
            if (!IsCount)
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto IsCount;
            }
            purchase:
            Helper.Print("Dermanin alis qiymetini daxil edin", ConsoleColor.Yellow);
            string dpurch = Console.ReadLine();
            bool isPur = double.TryParse(dpurch, out double dpurprice);
            if (dpurprice<=0)
            {

                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto purchase;
            }
            if (!isPur)
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto purchase;
            }
            if (Budget < (dpurprice * dcount))
            {
                Helper.Printslow($"Budceni kecdiyi ucun derman elave oluna bilmedi,MaxBudce: {Budget},Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
               goto IsCount;
            }
            saleprice:
            Helper.Print("Dermanin satis qiymetini daxil edin", ConsoleColor.Yellow);
            string dsal = Console.ReadLine();
            bool isSal = double.TryParse(dsal, out double saleprice);
            if (saleprice<=0)
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto saleprice;
            }
            if (!isSal)
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                goto saleprice;
            }
            
            drug.Name = dname;
            drug.Count = dcount;
            drug.PurchasePrice = dpurprice;
            drug.SalePrice = saleprice;
            drugs.Add(drug);
            Budget = Budget - (dpurprice * dcount);
            Console.Clear();
            Helper.Printslow($"{dname.ToUpper()} adli derman elave olundu , Umumi budce: {Budget}", ConsoleColor.Green);
        }
        public void DeletDrug()
        {
            if (drugs.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Hal hazirda bazada derman yoxdur!", ConsoleColor.Red);
                return;
            }
            Helper.Print("Axtardiqiniz dermanin adini daxil edin:", ConsoleColor.Yellow);
            string search = Console.ReadLine();
            List<Drug> druge = drugs.FindAll(x => x.Name.ToUpper().Contains(search.ToUpper()));
            if (druge.Count == 0)
            {Console.Clear();
                Helper.Printslow("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var item4 in druge)
            {

                Helper.Printslow($"ID: {item4.Id} Dernma Adi: {item4.Name.ToUpper()} Tip: {item4.DrugType}", ConsoleColor.Green);

            }
            did:
            Helper.Print("Silmek istediyiniz dermanin  ID qeyd edin", ConsoleColor.Yellow);
            string didd = Console.ReadLine();
            bool isId = int.TryParse(didd, out int did);
            if (!isId)
            {
                Helper.Printslow("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto did;
            }
            foreach (var item5 in drugs)
            {
                if (item5.Id == did)
                {
                    drugs.Remove(item5);
                    Budget = Budget + (item5.PurchasePrice * item5.Count);
                    Console.Clear();
                    Helper.Printslow($"{item5.Name.ToUpper()} adli derman silindi ,UMUMI BUDCE: {Budget}", ConsoleColor.Blue);
                    break;
                }
            }
        }
        public void EditDrug()
        {
            if (drugs.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Hal hazirda bazada derman yoxdur ", ConsoleColor.Red);
                return;
            }
            Helper.Print("Editlemek istediyiniz dermanin adini daxil edin:", ConsoleColor.Yellow);
            string edit = Console.ReadLine();
            List<Drug> druge = drugs.FindAll(x => x.Name.ToUpper().Contains(edit.ToUpper()));
            if (druge.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var item4 in druge)
            {

                Helper.Printslow($"ID: {item4.Id} AD: {item4.Name} Tip: {item4.DrugType}", ConsoleColor.Green);

            }
            didd:
            Helper.Print("Editlemek istediyiniz dermanin  ID qeyd edin", ConsoleColor.Yellow);
            string ddid = Console.ReadLine();
            bool isIdd = int.TryParse(ddid, out int _did);
            if (!isIdd)
            {
                Helper.Printslow("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto didd;
            }
            foreach (var item6 in drugs)
            {
                double oldpursh = item6.PurchasePrice;
                int count = item6.Count;
                DrugType dt = item6.DrugType;
                if (item6.Id == _did)
                {
                    Budget = Budget + (oldpursh * count);
                    newdrug:
                    Helper.Print("Derman yeni adini daxil edin", ConsoleColor.Yellow);
                    string dnname = Console.ReadLine();

                    IsnCount:
                    Helper.Print("Dermanin sayini qeyd edin", ConsoleColor.Yellow);
                    string dncoun = Console.ReadLine();
                    bool IsnCount = int.TryParse(dncoun, out int dncount);
                    if (dncount<=0)
                    {
                        Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto IsnCount;
                    }
                    if (!IsnCount)
                    {
                        Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto IsnCount;
                    }
                    npurchase:
                    Helper.Print("Dermanin alis qiymetini daxil edin", ConsoleColor.Yellow);
                    string dnpurch = Console.ReadLine();
                    bool isnPur = double.TryParse(dnpurch, out double dnpurprice);
                    if (dnpurprice<=0)
                    {
                        Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto npurchase;
                    }
                    if (!isnPur)
                    {
                        Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto npurchase;
                    }
                    if (Budget < (dnpurprice * dncount))
                    {
                        Helper.Printslow("Budceni kecdiyi ucun derman elave oluna bilmedi,Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto IsnCount;

                    }
                    nsaleprice:
                    Helper.Print("Dermanin satis qiymetini daxil edin", ConsoleColor.Yellow);
                    string dnsal = Console.ReadLine();
                    bool isnSal = double.TryParse(dnsal, out double nsaleprice);
                    if (nsaleprice<=0)
                    {
                        Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto nsaleprice;
                    }
                    if (!isnSal)
                    {
                        Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto nsaleprice;
                    }
                    
                    newtype:
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
                    else
                    {
                        Helper.Printslow("Yanlis daxil edildi,Zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto newtype;
                    }

                    if (dt == item6.DrugType&&dnname==item6.Name)
                    {
                        Helper.Printslow("Bu adli ve typl derman artiq movcuddur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto newdrug;
                    }

                    item6.Name = dnname;
                    item6.Count = dncount;
                    item6.PurchasePrice = dnpurprice;
                    item6.SalePrice = nsaleprice;
                    Budget = Budget - (dnpurprice * dncount);
                    Console.Clear();
                    Helper.Printslow($"{item6.Name.ToUpper()} addli derman editlendi ,UMUMI BUDCE : {Budget}", ConsoleColor.Blue);
                }
            }
        }
        public void DeletEmploye()
        {
            
            Helper.Print("Silmek istediyiniz emplooye adini qeyd edin", ConsoleColor.Yellow);
            string dem = Console.ReadLine();
            if (dem == "admin")
            {
                Helper.Printslow("SUPERADMIN siline bilmez!!", ConsoleColor.DarkRed);
                return;
            }
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(dem.ToUpper()));
            
            if (emp.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var em in emp)
            {
                Helper.Print($"ID: {em.Id} Ad: {em.Name} Tip :{em.RoleType}", ConsoleColor.Green);
            }
            _did:
            Helper.Print("Silmek istediyiniz emplooye  ID qeyd edin", ConsoleColor.Yellow);
            string ddidd = Console.ReadLine();
            bool isId_ = int.TryParse(ddidd, out int _didd);
            if (!isId_)
            {
                Helper.Printslow("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto _did;
            }
            if (_didd==1)
            {
                Helper.Printslow("SUPERADMIN siline bilmez!!", ConsoleColor.DarkRed);
                return;
            }
            foreach (var item5 in employees)
            {
                if (item5.Id == _didd)
                {
                    employees.Remove(item5);
                    Console.Clear();
                    Helper.Printslow($"{item5.Name.ToUpper()} adli emplooye silindi ", ConsoleColor.Blue);
                    break;
                }
            }
        }
        public void EditEmploye()
        {
            
            if (employees.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Hal hazirda bazada emplooye yoxdur", ConsoleColor.Red);
                return;
            }
            Helper.Print("Editlemek istediyiniz emplooye adini qeyd edin", ConsoleColor.Yellow);
            string edem = Console.ReadLine();
            if (edem=="admin")
            {
                Console.Clear();
                Helper.Printslow("SUPERADMIN editlene bilmez!!", ConsoleColor.DarkRed);
                return;
            }
            List<Employee> emp = employees.FindAll(x => x.Name.ToUpper().Contains(edem.ToUpper()));
            if (emp.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Bu adda hecne tapila bilmedi", ConsoleColor.Red);
                return;
            }
            foreach (var em in emp)
            {
                Helper.Print($"Id:{em.Id} AD: {em.Name.ToUpper()} Tip: {em.RoleType}", ConsoleColor.Green);
            }
            delid:
            Helper.Print("Editlemek istediyiniz emplooye  ID qeyd edin", ConsoleColor.Yellow);
            string delem = Console.ReadLine();
            bool isDel = int.TryParse(delem, out int delid);
            if (!isDel)
            {
                Helper.Printslow("Yanlis daxil edildi zehmet olmasa yeniden daxil edin:", ConsoleColor.Red);
                goto delid;
                ;
            }
            if (delid == 1)
            {
                Console.Clear();
                Helper.Printslow("SUPERADMIN editlene bilmez!!", ConsoleColor.DarkRed);
                return;
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
                        Helper.Printslow("Duzgun daxil edilmedi,Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                        goto dateTimee;
                    }
                    nesalary:
                    Helper.Print("Emplooyenin yeni salary qeyd edin ", ConsoleColor.Yellow);
                    string nesal = Console.ReadLine();
                    bool IsnSal = int.TryParse(nesal, out int nesalary);
                    if (!IsnSal)
                    {
                        Helper.Printslow($"Duzgun daxil edilmedi,MINIMUM: {MinSalary},Zehmet olmasa yeniden daxil edin!", ConsoleColor.Red);
                        goto nesalary;
                    }
                    if (nesalary < MinSalary)
                    {
                        Helper.Printslow("Bu mebleg aptekin shertlerin odemir, zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto nesalary;
                    }
                    neusername:
                    Helper.Print("Emplooye username daxil edin", ConsoleColor.Yellow);
                    string neusername = Console.ReadLine();
                    foreach (var item1 in employees)
                    {
                        if (item1.Username == neusername)
                        {
                            Helper.Printslow("Bu username artiq movcuddur,Zehmet olmasa bashqa username istifade edin", ConsoleColor.Red);
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
                            Helper.Printslow("Passwordda kicik herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else if (!hasUpperChar.IsMatch(password))
                        {
                            Helper.Printslow("Passwordda boyuk herif yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else if (!hasMiniMaxChars.IsMatch(password))
                        {
                            Helper.Printslow("Passwordda uzunluqu 6~15 araliqinda deyil,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else if (!hasNumber.IsMatch(password))
                        {
                            Helper.Printslow("Passwordda reqem yoxdur!,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }

                        else if (!hasSymbols.IsMatch(password))
                        {
                            Helper.Printslow("Passwordda xususi ishare yoxdur,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                            goto SETPASS;
                        }
                        else
                        {
                            edroletype:
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
                            else
                            {
                                Helper.Printslow("Duzgun daxil edilmedi,Yeniden daxil edin", ConsoleColor.Red);
                                goto edroletype;
                            }
                            item5.Name = newem;
                            item5.Surname = newsem;
                            item5.BirthDate = ndateTime;
                            item5.Salary = nesalary;
                            item5.Username = neusername;
                            item5.Password = password;
                            Console.Clear();
                            Helper.Printslow($"{item5.Name.ToUpper()} adli isci editlendi ", ConsoleColor.Blue);
                        }
                    }
                    else
                    {
                        Helper.Printslow("Passwordda uzunluqu 5den azdir  ,zehmet olmasa yeniden daxil edin", ConsoleColor.Red);
                        goto SETPASS;
                    }
                }
            }
        }
        public void Sale()
        {
            if (drugs.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Bazada derman yoxdu !!", ConsoleColor.Red);
                return;
            }
            Helper.Print("Derman adi daxil edin", ConsoleColor.DarkYellow);
            string dad = Console.ReadLine();
            Helper.Print("Derman tipini qeyd edin: syrob/powder/tablet?", ConsoleColor.DarkYellow);
            ddd:
            string dyit = Console.ReadLine();
            if (dyit.ToLower() != "syrob".ToLower() && dyit.ToLower() != "powder".ToLower() && dyit.ToLower() != "tablet".ToLower())
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.DarkRed);
                goto ddd;
            }
            dsay:
            Helper.Print("Sayini daxil edin", ConsoleColor.DarkYellow);
            string dsay = Console.ReadLine();
            bool isSay = int.TryParse(dsay, out int ddsay);
            if (!isSay)
            {
                Helper.Printslow("Yanlis daxil edildi,zehmet olmasa yeniden daxil edin", ConsoleColor.DarkRed);
                goto dsay;
            }

            List<Drug> drugess = drugs.FindAll(x => x.Name.ToUpper().Contains(dad.ToUpper()) && x.DrugType.ToString().ToUpper().Contains(dyit.ToUpper())/*&&x.Count>=ddsay*/);
            if (drugess.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Qalmayib", ConsoleColor.Red);
                return;
            }
            foreach (var druge in drugess)
            {
                if (druge.Count == 0)
                {
                    Console.Clear();
                    Helper.Printslow("Qalmayib", ConsoleColor.Red);
                    return;
                }
                if (druge.Count < ddsay)
                {
                    Helper.Printslow($"Qeyd etdiyiniz qeder yoxdur,{druge.Count} bu qeder derman var isteyirsinizmi?: yes/no", ConsoleColor.Blue);
                    yesno:
                    string yesno2 = Console.ReadLine();
                    int oldco = druge.Count;
                    if (yesno2.ToUpper() == "yes".ToUpper())
                    {
                        druge.Count = druge.Count - druge.Count;
                        Budget = Budget + (druge.SalePrice * oldco);
                        drugs.Remove(druge);
                        Console.Clear();
                        Helper.Printslow($"{druge.Name} adli derman satildi ,UMUMI BUDCE : {Budget}", ConsoleColor.Blue);
                        return;
                    }
                    else if (yesno2.ToUpper() == "no".ToUpper())
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Helper.Printslow("Yanlis daxil edildi,Yeniden daxil edin", ConsoleColor.Red);
                        goto yesno;
                    }
                }
                Helper.Print($"ID:{druge.Id} AD:{druge.Name} Say:{druge.Count} Tip:{druge.DrugType} SAtis qiymeti:{druge.SalePrice}", ConsoleColor.Yellow);
                yesno2:
                Helper.Print("Satis etmek istediynize eminsinizmi: yes/no?", ConsoleColor.Green);
                string yesno = Console.ReadLine();
                if (yesno.ToUpper() == "yes".ToUpper())
                {
                    druge.Count = druge.Count - ddsay;
                    Budget = Budget + (druge.SalePrice * ddsay);
                    Console.Clear();
                    Helper.Printslow($"{druge.Name.ToUpper()} adli derman {ddsay} eded satildi ,UMUMI BUDCE: {Budget}", ConsoleColor.Blue);
                }
                
                else if (yesno.ToUpper() == "no".ToUpper())
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Helper.Printslow("Yanlis daxil edildi,Yeniden daxil edin", ConsoleColor.Red);
                    goto yesno2;
                }
            }
        }
        public void SeeDrug() {
           
            if (drugs.Count == 0)
            {
                Console.Clear();
                Helper.Printslow("Bazada derman yoxdur!", ConsoleColor.DarkRed);
                return;
            }
            Console.Clear();
            foreach (var see in drugs)
            {
                Helper.Print($"ID:{see.Id} Ad: {see.Name} Tip: {see.DrugType} Say: {see.Count} Alis qiymeti: {see.PurchasePrice} Satis qiymeti: {see.SalePrice} Satisdan gelecek gelir: {(see.Count * see.SalePrice) - (see.Count * see.PurchasePrice)}", ConsoleColor.DarkMagenta);
            }
            return;
          
        }

    }
}
        

    




