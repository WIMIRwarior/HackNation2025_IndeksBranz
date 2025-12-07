library(eurostat)
library(tidyverse)
library(dplyr)
library(stringr)
install.packages("stringi")   
library(stringi)

#wczytanie danych
zbior_danych <- readxl::read_xlsx("zbior_danych.xlsx") %>%
  mutate(
    across(
      5:8,
      ~ as.numeric(sub(",", ".", as.character(.), fixed = TRUE))
    ))

#3 letnia analiza ale potrzebny 2021 do obliczenia dynamiki za 2022 
okres_analizy <- c("2021","2022", "2023", "2024")

zbior <- pivot_longer(zbior_danych,
  cols= starts_with("20"),
  names_to = "Data",
  values_to = "Wartosc"
)
  

zbior_2 <- pivot_wider(zbior,
          names_from = "wskaźnik",
          values_from = "Wartosc") %>%
  rename(PKD = starts_with("numer PKD"),
         NAZWA_PKD = starts_with("nazwa PKD")) %>%
  mutate(NAZWA_PKD = gsub(";", ",", as.character(NAZWA_PKD), fixed = TRUE)
  )
  

#wyciagniecie ogolnej gospodarki do porownan
ogol_gospodarki <- zbior_2 %>%
  filter(PKD == "OG")

#dostosowanie nazw
ogol_gospodarki2 <- ogol_gospodarki %>%
  rename(
    Liczba_jednostek_gospodarczych        = starts_with("EN Liczba"),
    Liczba_rentownych_jednostek_gospodarczych = starts_with("PEN Liczba rentownych"),
    Przychody_netto                       = starts_with("PNPM Przychody netto"),
    Zysk_netto                            = starts_with("NP Wynik finansowy netto"),
    Sprzedaz                              = starts_with("POS Wynik na sprzedaży"),
    Koszty                                = starts_with("TC Koszty ogółem"),
    Odsetki                               = starts_with("IP Odsetki do zapłacenia"),
    Naklady_inwestycyjne                  = starts_with("IO Wartość nakładów inwestycyjnych"),
    Srodki_pieniezne_pap_wart             = starts_with("C Środki pieniężne i pap. wart"),
    Zobowiazania_dlugoterminowe           = starts_with("LTL Zobowiązania długoterminowe"),
    Zobowiazania_krotkoterminowe          = starts_with("STL Zobowiązania krótkoterminowe"),
    Krotko_terminowe_kredyty_bankowe      = starts_with("STC Krótkoterminowe kredyty bankowe"),
    Dlugo_terminowe_kredyty_bankowe       = starts_with("LTC Długoterminowe kredyty bankowe"),
    Zapasy                                = starts_with("INV Zapasy")
  ) %>%
  select(PKD, NAZWA_PKD, Data,Liczba_jednostek_gospodarczych,
         Liczba_rentownych_jednostek_gospodarczych,Przychody_netto,Zysk_netto,
         Sprzedaz,Koszty,Odsetki,Naklady_inwestycyjne,Srodki_pieniezne_pap_wart,
         Zobowiazania_dlugoterminowe,Zobowiazania_krotkoterminowe,
         Krotko_terminowe_kredyty_bankowe,Dlugo_terminowe_kredyty_bankowe, Zapasy) %>%
  mutate(Rentownosc_sprzedazy =((Zysk_netto/Sprzedaz)*100))

#zawezenie do 4 ostatnich lat
ogol_gospodarki3 <- ogol_gospodarki2 %>%
  filter(Data %in% okres_analizy)


#sekcje dzialowe
df_ok <- zbior_2 %>% 
  filter(str_detect(PKD, "^(0[1-9]|[1-9][0-9])\\.$")) %>%
  mutate(
   PKD = PKD %>%
      str_remove("\\.$") %>%   
      as.integer()             
  )


#dostosowanie nazw
df_ok2 <- df_ok %>%
  rename(
    Liczba_jednostek_gospodarczych        = starts_with("EN Liczba"),
    Liczba_rentownych_jednostek_gospodarczych = starts_with("PEN Liczba rentownych"),
    Przychody_netto                       = starts_with("PNPM Przychody netto"),
    Zysk_netto                            = starts_with("NP Wynik finansowy netto"),
    Sprzedaz                              = starts_with("POS Wynik na sprzedaży"),
    Koszty                                = starts_with("TC Koszty ogółem"),
    Odsetki                               = starts_with("IP Odsetki do zapłacenia"),
    Naklady_inwestycyjne                  = starts_with("IO Wartość nakładów inwestycyjnych"),
    Srodki_pieniezne_pap_wart             = starts_with("C Środki pieniężne i pap. wart"),
    Zobowiazania_dlugoterminowe           = starts_with("LTL Zobowiązania długoterminowe"),
    Zobowiazania_krotkoterminowe          = starts_with("STL Zobowiązania krótkoterminowe"),
    Krotko_terminowe_kredyty_bankowe      = starts_with("STC Krótkoterminowe kredyty bankowe"),
    Dlugo_terminowe_kredyty_bankowe       = starts_with("LTC Długoterminowe kredyty bankowe"),
    Zapasy                                = starts_with("INV Zapasy")
  ) %>%
  select(PKD, NAZWA_PKD, Data,Liczba_jednostek_gospodarczych,
         Liczba_rentownych_jednostek_gospodarczych,Przychody_netto,Zysk_netto,
         Sprzedaz,Koszty,Odsetki,Naklady_inwestycyjne,Srodki_pieniezne_pap_wart,
         Zobowiazania_dlugoterminowe,Zobowiazania_krotkoterminowe,
         Krotko_terminowe_kredyty_bankowe,Dlugo_terminowe_kredyty_bankowe, Zapasy) %>%
  mutate(PKD = as.character(PKD),
         Rentownosc_sprzedazy = ((Zysk_netto/Sprzedaz)*100))

#zawezenie do 4 ostatnich lat
df_ok3 <- df_ok2 %>%
  filter(Data %in% okres_analizy)

#dodanie wynikow dla calej gospodarki 
df_og_dyn <- bind_rows(df_ok3, ogol_gospodarki3)

#dynamiki
df_dyn <- df_og_dyn %>%
  group_by(PKD) %>%
  mutate(Dynamika_liczba_jednostek_gospodarczych = (Liczba_jednostek_gospodarczych/lag(Liczba_jednostek_gospodarczych)-1)*100,
         Dynamika_liczba_rentownych_jednostek_gospodarczych= (Liczba_rentownych_jednostek_gospodarczych/lag(Liczba_rentownych_jednostek_gospodarczych)-1)*100,
         Dynamika_przychody_netto= (Przychody_netto/lag(Przychody_netto)-1)*100,
         Dynamika_zysk_netto= (Zysk_netto  /lag(Zysk_netto  )-1)*100,
         Dynamika_sprzedaz= (Sprzedaz/lag(Sprzedaz)-1)*100, 
         Dynamika_koszty= (Koszty/lag(Koszty)-1)*100,
         Dynamika_odsetki = (Odsetki/lag(Odsetki)-1)*100 ,
         Dynamika_naklady_inwestycyjne= (Naklady_inwestycyjne/lag(Naklady_inwestycyjne)-1)*100,
         Dynamika_zobowiazania_krotkoterminowe=(Zobowiazania_krotkoterminowe/lag(Zobowiazania_krotkoterminowe)-1)*100,
         Dynamika_zobowiazania_dlugoterminowe=(Zobowiazania_dlugoterminowe/lag(Zobowiazania_dlugoterminowe)-1)*100,
         Dynamika_srodki_pieniezne_pap_wart =(Srodki_pieniezne_pap_wart/lag(Srodki_pieniezne_pap_wart)-1)*100,
         Dynamika_krotko_terminowe_kredyty_bankowe=(Krotko_terminowe_kredyty_bankowe/lag(Krotko_terminowe_kredyty_bankowe)-1)*100,
         Dynamika_dlugo_terminowe_kredyty_bankowe=(Dlugo_terminowe_kredyty_bankowe/lag(Dlugo_terminowe_kredyty_bankowe)-1)*100, 
         Dynamika_zapasy=(Zapasy/lag(Zapasy)-1)*100,
         Dynamika_rentownosc_sprzedazy =(Rentownosc_sprzedazy/lag(Rentownosc_sprzedazy)-1)*100) %>%
    ungroup() %>%
  filter(Data != "2021") %>%
  mutate(NAZWA_PKD = stri_trans_general(NAZWA_PKD, "Latin-ASCII")) %>%
  select(-Rentownosc_sprzedazy)
df_dyn[is.na(df_dyn)] <- 0

#zapis do csv
write.csv2(df_dyn, "Dynamiki_poziomy.csv", row.names = FALSE)

#syntetyczny wskaznik stanu branz, jaki znak gdy dynamika powyzej gospodarki
# liczba firm na plus gdy powyzej gospodarki
# liczba firm na plus gdy powyzej gospodarki
# przychody netto na plus gdy powyzej gospodarki
# zysk netto na plus gdy powyzej gospodarki
# sprzedaz na plus gdy powyzej gospodarki
# koszty ogolem na minus gdy powyzej gospodarki
# odsetki na minus gdy powyzej gospodarki
# naklady inwestycyjne na plus gdy powyzej gospodarki
# zobowiazania na minus gdy powyzej gospodarki ale dlugterminowe slabiej na minus
# srodki pieniezne na plusgdy powyzej gospodarki
# kredyty bankowe na minus gdy powyzej gospodarki ale dlugterminowe slabiej na minus
# zapasy na minus na minus gdy powyzej gospodarki ale slabiej na minus

#15 wskaznikow sie sumuje i przedstawia stan 

df_oceny_ryzyka <- df_dyn %>%
  select(PKD, NAZWA_PKD, Data, Dynamika_liczba_jednostek_gospodarczych,
         Dynamika_liczba_rentownych_jednostek_gospodarczych, Dynamika_przychody_netto,
         Dynamika_zysk_netto, Dynamika_sprzedaz, Dynamika_koszty, Dynamika_odsetki,
         Dynamika_naklady_inwestycyjne, Dynamika_zobowiazania_krotkoterminowe, Dynamika_zobowiazania_dlugoterminowe,
         Dynamika_srodki_pieniezne_pap_wart, Dynamika_krotko_terminowe_kredyty_bankowe,
         Dynamika_dlugo_terminowe_kredyty_bankowe, Dynamika_zapasy, Dynamika_rentownosc_sprzedazy) %>%
  group_by(NAZWA_PKD) %>%
  summarise(across(starts_with("Dynamika_"), ~ mean(.x, na.rm = TRUE))
  ) %>%
  ungroup() 

#wiersz 43 zawiera dane na temat calej gospodarki co traktujemy jako swoisty benchmark
  df_punktacja <- df_oceny_ryzyka %>%
    mutate(
      Punktacja_liczba_jednostek_gospodarczych = case_when(
        Dynamika_liczba_jednostek_gospodarczych > Dynamika_liczba_jednostek_gospodarczych[43] ~ 2,
        Dynamika_liczba_jednostek_gospodarczych > 0 ~ 1,
        Dynamika_liczba_jednostek_gospodarczych == 0 ~ 0 ,
        Dynamika_liczba_jednostek_gospodarczych < 0 ~ -1,
        Dynamika_liczba_jednostek_gospodarczych < Dynamika_liczba_jednostek_gospodarczych[43] ~ -2
      ),
      Punktacja_liczba_rentownych_jednostek_gospodarczych = case_when(
        Dynamika_liczba_rentownych_jednostek_gospodarczych > Dynamika_liczba_rentownych_jednostek_gospodarczych[43] ~2,
        Dynamika_liczba_rentownych_jednostek_gospodarczych > 0 ~ 1,
        Dynamika_liczba_rentownych_jednostek_gospodarczych == 0 ~ 0 ,
        Dynamika_liczba_rentownych_jednostek_gospodarczych < 0 ~ -1,
        Dynamika_liczba_rentownych_jednostek_gospodarczych < Dynamika_liczba_rentownych_jednostek_gospodarczych[43] ~ -2
      ),
      Punktacja_przychody_netto = case_when(
        Dynamika_przychody_netto > Dynamika_przychody_netto[43] ~ 2,
        Dynamika_przychody_netto > 0 ~ 1,
        Dynamika_przychody_netto == 0 ~ 0 ,
        Dynamika_przychody_netto < 0 ~ -1,
        Dynamika_przychody_netto < Dynamika_przychody_netto[43] ~ -2
      ),
      Punktacja_zysk_netto = case_when(
        Dynamika_zysk_netto > Dynamika_zysk_netto[43] ~ 2,
        Dynamika_zysk_netto > 0 ~ 1,
        Dynamika_zysk_netto == 0 ~ 0 ,
        Dynamika_zysk_netto < 0 ~ -1,
        Dynamika_zysk_netto < Dynamika_zysk_netto[43] ~ -2
      ),
      Punktacja_sprzedaz = case_when(
        Dynamika_sprzedaz > Dynamika_sprzedaz[43] ~ 2,
        Dynamika_sprzedaz > 0 ~ 1,
        Dynamika_sprzedaz == 0 ~ 0 ,
        Dynamika_sprzedaz < 0 ~ -1,
        Dynamika_sprzedaz < Dynamika_sprzedaz[43] ~ -2
      ),
      Punktacja_koszty = case_when(
        Dynamika_koszty > Dynamika_koszty[43] ~ -2,
        Dynamika_koszty > 0 ~ -1,
        Dynamika_koszty == 0 ~ 0 ,
        Dynamika_koszty < 0 ~ 1,
        Dynamika_koszty < Dynamika_koszty[43] ~ 2
      ),
      Punktacja_odsetki = case_when(
        Dynamika_odsetki > Dynamika_odsetki[43] ~ -2,
        Dynamika_odsetki > 0 ~ -1,
        Dynamika_odsetki == 0 ~ 0 ,
        Dynamika_odsetki < 0 ~ 1,
        Dynamika_odsetki < Dynamika_odsetki[43] ~ 2
      ),
      Punktacja_naklady_inwestycyjne = case_when(
        Dynamika_naklady_inwestycyjne > Dynamika_naklady_inwestycyjne[43] ~ 2,
        Dynamika_naklady_inwestycyjne > 0 ~ 1,
        Dynamika_naklady_inwestycyjne == 0 ~ 0 ,
        Dynamika_naklady_inwestycyjne < 0 ~ -1,
        Dynamika_naklady_inwestycyjne < Dynamika_naklady_inwestycyjne[43] ~ -2
      ),
      Punktacja_zobowiazania_krotkoterminowe = case_when(
        Dynamika_zobowiazania_krotkoterminowe > Dynamika_zobowiazania_krotkoterminowe[43] ~ -2,
        Dynamika_zobowiazania_krotkoterminowe > 0 ~ -1,
        Dynamika_zobowiazania_krotkoterminowe == 0 ~ 0 ,
        Dynamika_zobowiazania_krotkoterminowe < 0 ~ 1,
        Dynamika_zobowiazania_krotkoterminowe < Dynamika_zobowiazania_krotkoterminowe[43] ~ 2
      ),
      Punktacja_zobowiazania_dlugoterminowe = case_when(
        Dynamika_zobowiazania_dlugoterminowe > Dynamika_zobowiazania_dlugoterminowe[43] ~ -1,
        Dynamika_zobowiazania_dlugoterminowe > 0 ~ -0.5,
        Dynamika_zobowiazania_dlugoterminowe == 0 ~ 0 ,
        Dynamika_zobowiazania_dlugoterminowe < 0 ~ 0.5,
        Dynamika_zobowiazania_dlugoterminowe < Dynamika_zobowiazania_dlugoterminowe[43] ~ 1
      ),
      Punktacja_srodki_pieniezne_pap_wart = case_when(
        Dynamika_srodki_pieniezne_pap_wart > Dynamika_srodki_pieniezne_pap_wart[43] ~2,
        Dynamika_srodki_pieniezne_pap_wart > 0 ~1,
        Dynamika_srodki_pieniezne_pap_wart == 0 ~ 0 ,
        Dynamika_srodki_pieniezne_pap_wart < 0 ~ -1,
        Dynamika_srodki_pieniezne_pap_wart < Dynamika_srodki_pieniezne_pap_wart[43] ~ -2
      ),
      Punktacja_krotko_terminowe_kredyty_bankowe = case_when(
        Dynamika_krotko_terminowe_kredyty_bankowe > Dynamika_krotko_terminowe_kredyty_bankowe[43] ~ -2,
        Dynamika_krotko_terminowe_kredyty_bankowe > 0 ~ -1,
        Dynamika_krotko_terminowe_kredyty_bankowe == 0 ~ 0 ,
        Dynamika_krotko_terminowe_kredyty_bankowe < 0 ~ 1,
        Dynamika_krotko_terminowe_kredyty_bankowe < Dynamika_krotko_terminowe_kredyty_bankowe[43] ~ 2
      ),
      Punktacja_dlugo_terminowe_kredyty_bankowe = case_when(
        Dynamika_dlugo_terminowe_kredyty_bankowe > Dynamika_dlugo_terminowe_kredyty_bankowe[43] ~ -1,
        Dynamika_dlugo_terminowe_kredyty_bankowe > 0 ~ -0.5,
        Dynamika_dlugo_terminowe_kredyty_bankowe == 0 ~ 0 ,
        Dynamika_dlugo_terminowe_kredyty_bankowe < 0 ~ 0.5,
        Dynamika_dlugo_terminowe_kredyty_bankowe < Dynamika_dlugo_terminowe_kredyty_bankowe[43] ~ 1
      ),
      Punktacja_zapasy = case_when(
        Dynamika_zapasy > Dynamika_zapasy[43] ~ -1,
        Dynamika_zapasy > 0 ~ -0.5,
        Dynamika_zapasy == 0 ~ 0 ,
        Dynamika_zapasy < 0 ~ 0.5,
        Dynamika_zapasy < Dynamika_zapasy[43] ~ 1
      ),
      Punktacja_rentownosc_sprzedazy = case_when(
        Dynamika_rentownosc_sprzedazy > Dynamika_rentownosc_sprzedazy[43] ~ 2,
        Dynamika_rentownosc_sprzedazy > 0 ~ 1,
        Dynamika_rentownosc_sprzedazy == 0 ~ 0 ,
        Dynamika_rentownosc_sprzedazy < 0 ~ -1,
        Dynamika_rentownosc_sprzedazy < Dynamika_rentownosc_sprzedazy[43] ~ -2
      )
    ) %>%
    mutate(
      suma_punktacji = rowSums(across(starts_with("Punktacja_")), na.rm = TRUE)
    )%>%
    filter(NAZWA_PKD != "OGOLEM")
         
        
#zapis do csv 
write.csv2(df_punktacja, "Indeks_branz.csv", row.names = FALSE)
