# **Dokumentace k modelu obchodu(CZ)**
### Verze:
1.0
### Obor:
INFOP
### Předmět:
Objektové modelování
### Autor:
Ron Studený
### Kontakt:
XSTUR008@studenti.czu.cz

# 1 Informace o modelu
## 1.1 Realizace
Model je realizován v konzolové aplikaci C# s použitím frameworku .NET 6.0. Dotazy jsou implementovány pomocí LINQ a kolekce jsou reprezentovány obecnými kolekcemi ``List<T>``. Toto prostředí jsem zvolil pro jeho přizpůsobivost a jednoduchost použití, stejně jako pro mou předchozí zkušenost.
## 1.2 Účel
Tento model slouží jako ukázka toho, jak by mohl vnitřní databázový / systémový model pro obchod s potravinami vypadat, a jako demonstrace toho, že by se tento model dal do aplikace / rozhraní integrovat 
## 1.3 Rozsah
Rozsah tohoto modelu je zmenšen tak, aby nebyl příliš složitý. Implementuje 5 tříd, které představují samotný obchod, jeho zaměstnance, zákazníky a položky; navíc bylo implementováno 5 dotazů k demonstraci funkčnosti tohoto modelu. **Žádné spojení** s reálnou databází nebo aplikací nebylo implementováno.

# 2 Topologie modelu
## 2.1 Třída Obchod
Toto je hlavní třída, kolem které je celý systém postaven, a obsahuje kolekce všech zbývajících tříd. V rámci **1.3 Rozsahu** existuje v modelu pouze 1 instance této třídy; model by měl pouze reprezentovat systém pro jeden obchod, nicméně tato třída je implementována tak, že lze v rámci jednoho systému vytvářet a zpracovávat více obchodů.<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Proměnná obsahující název zařízení; v případě rozšíření použití tohoto modelu na podporu více obchodů by se tato proměnná mohla použít k identifikaci.<br>
``List<Employee> Employees`` - Kolekce typu ``Employee``, obsahuje všechny instance třídy ``Employee``. Tato kolekce je široce využívána v celém projektu, jak bude dále popsáno v dokumentaci.<br>
``List<Person> Customers`` - Kolekce typu ``Person``, má několik použití: představuje všechny lidi, kteří provedli nákup, ale také ty, kteří to neudělali, ale mohou to udělat v budoucnu. Taková funkce by mohla být použita jako registrační a účetní systém v případě, že by model byl rozšířen na službu elektronického obchodu.<br>
``List<Item> ItemsAvailable`` - Kolekce typu ``Item``, slouží jako souhrn všech produktů, které obchod nabízí. Důležitá kolekce v jakémkoli typu aplikace nebo rozhraní, do kterého může být tento model začleněn.<br>
``List<Transaction> Transaction`` - Kolekce typu ``Transaction``, je to kolekce všech transakcí v obchodě. Další důležitá kolekce, která může být použita k sledování prodejů, hrubého příjmu, ověření, kolik času zaměstnanci stráví u pokladny atd.<br>
## 2.2 Třída Osoba
Tato třída slouží k reprezentaci zákazníka v obchodě, který mohl provést nákup. Navíc tato třída ``Person`` je rodičem třídy ``Employee``, takže se ``Employee`` může považovat také za zákazníka.<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Proměnná obsahující křestní jméno osoby, používá se k základní identifikaci mezi potenciálně velkou kolekcí dalších zákazníků.<br>
``string Surname`` - Proměnná obsahující příjmení osoby, stejné použití jako proměnná ``Name``.<br>
``DateTime DoB`` - Proměnná obsahující datum narození osoby, používá se k výpočtu ``Age`` a může být také použita k filtrování určitých zákazníků.<br>
``int Age`` - Proměnná obsahující věk osoby, vypočítává se na vyžádání na základě data narození osoby a aktuálního data. Používá se k ověření, zda mohou zakoupit určité produkty, které mohou být omezeny věkem.<br>
## 2.3 Třída Zaměstnanec
Jak bylo zmíněno výše, tato třída je dítětem třídy ``Person``. Představuje zaměstnance, kteří jsou zodpovědní za provoz zařízení, a jsou uvedeni odděleně od zákazníků ve třídě ``Store``.<br> Tato třída může být použita k sledování pracovní doby zaměstnanců, plat, který obdrželi, prodané produkty atd.<br>
----INSTANCE VARIABLES----<br>
**VŠECHNY PROMĚNNÉ Z TŘÍDY ``PERSON`` JSOU PŘÍTOMNY V TÉTO TŘÍDĚ TAKÉ**<br>
``Guid EmployeeID`` - Jedinečná proměnná identifikující každého zaměstnance, používá se jako primární identifikace.<br>
``bool HasManagerRights`` - Nepovinná proměnná (výchozí hodnota false), která popisuje, zda zaměstnanec má manažerská práva; použití této proměnné je třeba stanovit politikou obchodu.<br>
``float HourlyWage`` - Proměnná, která může být použita k sledování, kolik by měl zaměstnanec dostávat za hodinu práce. Informace, která se může hodit v integrovaném systému. Používá se k výpočtu ``Salary`` zaměstnanců.<br>
``float HoursWorked`` - Proměnná používaná k sledování, kolik hodin zaměstnanec odpracoval během měsíce, používá se také při výpočtu ``Salary``.<br>
``float Salary`` - Proměnná, která vrací součin proměnných ``HourlyWage`` a ``HoursWorked``, užitečná k sledování, kolik by zaměstnanec měl být odměněn za svou práci.<br>
## 2.4 Třída Položka
Tato třída představuje jedinečný produkt, který je k prodeji v obchodě. Jeho instance tvoří druh katalogu položek, které jsou odkazovány pokaždé, když je zákazníkem koupí, místo aby reprezentovaly objem této položky na skladě<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Proměnná obsahující název produktu, jedna z hlavních možností při třídění produktů je hledání podle jména.<br>
``string ProductType`` - Další proměnná užitečná pro třídění dostupných položek, uživatel by mohl chtít vybrat širší výběr položek se stejným použitím, což by bylo provedeno pomocí této proměnné.<br>
``string Description`` - Méně důležitá proměnná obsahující slovní popis produktu, mohla by být implementována do služby elektronického obchodu, pokud by byla potřeba.<br>
``string Firm`` - Název firmy zodpovědné za výrobu daného produktu, užitečný pro další možnosti třídění.<br>
``DateTime ExpirationDate`` - Nepovinná proměnná obsahující datum expirace poskytnuté výrobcem, převážně užitečná pro potravinářské produkty.<br>
``string BarCodeID`` - Čárový kód položky, jedinečný pro každou instanci, v modelu je vytvořena instance Guid k reprezentaci každé položky, tato může být však změněna tak, aby odpovídala skutečnému inventáři obchodu.<br>
``float Price`` - Cena položky, používá se k výpočtu celkové ceny ``Transaction``.<br>
``int LegalAge`` - Výchozí hodnota 0, nepovinná proměnná, která může být nastavena na jakýkoli věk, který by měl zákazník dosáhnout, aby mohl zakoupit danou položku.<br>
``bool IsExpired`` - Implementováno funkcí, kontroluje, zda aktuální datum překračuje ``ExpirationDate`` položky a vrátí příslušnou hodnotu.<br>

## 2.5 Třída Transakce
Další hlavní třída, reprezentuje transakci mezi obchodem a zákazníkem, obsahuje všechny důležité informace, jako je pokladník ``Employee``, který provedl transakci, zákazník ``Person``, položky, které byly zakoupeny atd.<br>
----INSTANCE VARIABLES----<br>
``Employee Cashier`` - Pokladník, který byl zodpovědný za finalizaci transakce. Užitečné pro třídění kolekce ``Transaction``.<br>
``Person Customer`` - Zákazník, který provedl nákup, užitečné pro určení faktorů, jako je splnění zákonného věku pro zakoupení položek v transakci.<br>
``List<Item> PurchasedItems`` - Kolekce typu ``Item``, obsahuje odkazy na jednotlivé položky z kolekce ``ItemsAvailable`` v ``Store``, přičemž každý odkaz představuje nákup jednotlivé položky tohoto typu.<br>
``DateTime DateOfPurchase`` - Obsahuje datum vytvoření dané instance. Automaticky generováno pomocí konstruktoru, užitečné pro třídění, indexaci.<br>
``Guid TransactionID`` - Automaticky generované jedinečné ID přiřazené transakci pro identifikaci.<br>
``double TotalPrice`` - Sčítá hodnotu ``Price`` každého odkazu na položku z kolekce ``PurchasedItems``, což vede k celkové ceně zaplacené zákazníkem; implementováno jako getter funkce<.br>

# 3 Funkčnost
## 3.1 Dotazy
Pro otestování schopností modelu bylo implementováno 5 dotazů spolu s jednoduchým programem na vizualizaci výsledků těchto dotazů za účelem demonstrování jeho funkčnosti<br>
``GetIlleGalPurchases`` - Vrací kolekci typu ``Transaction`` obsahující všechny transakce, které obsahují ``Item`` s vyšším údajem o ``LegalAge`` než údaj o ``Age`` proměnné ``Customer``<br>
``GetTransactionsOverAPrice`` - Tento dotaz přijímá float, který představuje požadovanou cenu, a vrací kolekci ``Transaction`` obsahující transakce s údajem o ``TotalPrice`` vyšším než daná cena<br>
``GetItemsSoldByEmployee`` - Tento dotaz přijímá parametr ``Employee`` a vrací kolekci typu ``Item`` obsahující všechny položky, které byly v transakci vytvořeny daným zaměstnancem<br>
``GetItemsSoldByCustomer`` - Podobně jako předchozí dotaz přijímá parametr typu ``Person`` a vrací kolekci typu ``item`` obsahující všechny položky, které byly v transakci obsaženy s daným parametrem<br>
``GetEmployeesThatAreCustomers`` - Vrací kolekci typu ``Employee``, která obsahuje všechny zaměstnance, kteří jsou také obsaženi v kolekci ``Customers`` v ``Store``<br>
