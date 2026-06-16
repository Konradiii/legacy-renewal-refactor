# Legacy Renewal Refactor

Refaktoryzacja aplikacji `LegacyRenewalApp` (C# / .NET) — poprawa jakości kodu odnawiania subskrypcji zgodnie z zasadami **SOLID**, **DRY** oraz dobrymi praktykami projektowymi, bez zmiany zachowania biznesowego aplikacji.

## Opis

Punktem wyjścia jest działająca, ale źle zaprojektowana aplikacja, w której logika odnawiania subskrypcji skupiona jest w jednej rozbudowanej metodzie. Celem projektu była refaktoryzacja kodu — poprawa jego struktury, czytelności i utrzymywalności — przy zachowaniu identycznego zachowania z perspektywy kodu klienckiego.

Kluczowe ograniczenia, których refaktoryzacja musiała przestrzegać:
- zachowanie publicznego kontraktu używanego przez kod kliencki (`LegacyRenewalAppConsumer` pozostaje niezmieniony),
- brak modyfikacji zewnętrznej, statycznej klasy `LegacyBillingGateway` — ograniczenie sprzężenia z nią poprzez własną abstrakcję,
- zachowanie dotychczasowego wyniku działania (refaktoryzacja jakości, nie zmiana funkcjonalności).

## Zidentyfikowane problemy kodu wyjściowego

Klasa `SubscriptionRenewalService` łamała zasadę pojedynczej odpowiedzialności — jedna metoda mieszała walidację, dostęp do danych, logikę rabatów, opłat dodatkowych i podatków, budowanie i zapis faktury oraz wysyłkę e-maila. Dodatkowo występowały rozbudowane bloki `if-else`, bezpośrednie tworzenie zależności wewnątrz serwisu i bezpośrednie użycie statycznej klasy zewnętrznej (wysoki coupling, niska kohezja).

## Zastosowane techniki refaktoryzacji

- **Single Responsibility** — podział monolitycznej metody na osobne klasy/serwisy domenowe, każdy z jedną odpowiedzialnością (walidacja, rabaty, opłaty, podatki, fakturowanie, powiadomienia).
- **Dependency Inversion + IoC** — wprowadzenie abstrakcji (interfejsów) i wstrzykiwanie zależności zamiast tworzenia ich wewnątrz serwisu.
- **Open/Closed Principle** — zastąpienie rozbudowanych bloków `if-else` zestawem interfejsów i implementacji (np. strategie rabatów), umożliwiając rozszerzanie bez modyfikacji istniejącego kodu.
- **Opakowanie zależności zewnętrznej** — `LegacyBillingGateway` ukryty za własnym interfejsem, co ogranicza sprzężenie i ułatwia testowanie.
- **DRY** — usunięcie powtórzeń i wydzielenie wspólnej logiki.
- **Kohezja / coupling** — zwiększenie spójności klas i zmniejszenie zależności między nimi.

## Technologie

- C# / .NET
- Zasady SOLID, DRY
- Dependency Injection / Inversion of Control

## Struktura

- `LegacyRenewalApp` - refaktoryzowany kod aplikacji.
- `LegacyRenewalAppConsumer` - kod kliencki (niemodyfikowany, weryfikuje zachowanie publicznego kontraktu).
- `LegacyBillingGateway` - zewnętrzna klasa statyczna (niemodyfikowana, opakowana we własną abstrakcję).
