# .NET Multithreading Lab3

Projekt wykonany w ramach laboratorium w technologii .NET.

## Opis

Projekt składa się z trzech części:

### Zadanie 1
Mnożenie macierzy z użyciem `Parallel.For`.  
Pomiar czasu wykonania oraz analiza przyspieszenia względem jednego wątku.

### Zadanie 2
Mnożenie macierzy z wykorzystaniem klasy `Thread`.  
Ręczne zarządzanie wątkami oraz porównanie wydajności z podejściem `Parallel`.

### Zadanie 3
Aplikacja Windows Forms do równoległego przetwarzania obrazów, jako przykład wykorzystujący klasę `Thread` w praktycznym rozwiązaniu.  
Każdy filtr wykonywany jest w osobnym wątku:
- odcienie szarości
- negatyw
- progowanie
- odbicie lustrzane

## Wyniki testów do zadań 1 i 2
Rozmiar | Wątki | Parallel avg [ms] | Thread avg [ms] | SpeedUp Parallel | SpeedUp Thread | Poprawny
---------------------------------------------------------------------------------------------------
200     | 1     | 277,20            | 321,40          | 1,78             | 1,23           | True
200     | 2     | 93,00             | 149,20          | 5,29             | 2,66           | True
200     | 4     | 79,20             | 204,20          | 6,21             | 1,94           | True
200     | 8     | 82,40             | 230,60          | 5,97             | 1,72           | True
200     | 16    | 76,60             | 322,60          | 6,43             | 1,23           | True
200     | 32    | 83,60             | 552,40          | 5,89             | 0,72           | True

300     | 1     | 706,20            | 913,40          | 1,18             | 0,95           | True
300     | 2     | 389,00            | 512,60          | 2,14             | 1,69           | True
300     | 4     | 427,40            | 721,60          | 1,94             | 1,20           | True
300     | 8     | 610,60            | 907,40          | 1,36             | 0,95           | True
300     | 16    | 615,00            | 1108,00         | 1,35             | 0,78           | True
300     | 32    | 570,40            | 1342,20         | 1,46             | 0,65           | True

500     | 1     | 3707,40           | 4128,60         | 2,32             | 1,65           | True
500     | 2     | 4791,60           | 4425,80         | 1,79             | 1,54           | True
500     | 4     | 2594,60           | 3123,80         | 3,31             | 2,18           | True
500     | 8     | 2634,80           | 2957,00         | 3,26             | 2,30           | True
500     | 16    | 1095,20           | 1868,60         | 7,84             | 3,64           | True
500     | 32    | 1795,40           | 5673,20         | 4,78             | 1,20           | True

## Wnioski

- Implementacja z użyciem `Parallel.For` osiąga lepsze wyniki niż ręczne zarządzanie wątkami (`Thread`).
- Największe przyspieszenie obserwowane jest dla większych rozmiarów macierzy (np. 500x500).
- Wraz ze wzrostem liczby wątków przyspieszenie rośnie, ale tylko do pewnego momentu.
- Dla zbyt dużej liczby wątków (np. 32) wydajność spada ze względu na narzut zarządzania wątkami.
- `Thread` ma większy narzut i gorzej się skaluje niż `Parallel`.
- Wszystkie wyniki są poprawne (`Poprawny = True`), co oznacza brak błędów synchronizacji.