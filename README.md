*** Baza Podataka ***
U Models folderu se nalaze klase koje inicijaliziraju bazu podataka u (localdb)\v11.0 ako ne postoji. Model je osmišljen kao veza N:N te se sastoji od 3 tablice: Mp3Files, SeNalaziNa i Playlista. Prilikom inicijalizacije tablice se popunjavaju testnim podacima.



*** Kontrole ***
U Controllers folderu se nalazi kontrola Mp3FilesController u kojoj se trenutno nalaze metode za dohvaćanje/uređivanje/brisanje Mp3 datoteka.


*** Pogledi ***
U folderu Home direktorija Views se nalazi Index pogled preko kojeg se prikazuju sadržaji baze podataka pomoću angular.js-a. U _Layout pogledu u folderu Shared je referenca na angular modul. 


*** Skripte ***
Angular skripta se nalazi u folderu Scripts/app pod nazivom mojaSkripta.js u kojoj se trenutno nalaze funkcije za dodavanje/dohvat/uređivanje/brisanje.