## Тестирование по направлению «Стажер - программист»

### Обоснование реализации задания

Так как входными данными является список строк формата X:Y (без указания команд) - реализация предполагает, что матчи проводились между одной "домашней" и одной "гостевой" командой.

Также, исходя из данных фрагментов текста задания:

> Исходя из логики, что за победу в домашних матчах дается 3 очка, за ничью 1
очко, за поражение 0 очков.

> Например, счет матча "3:1":
Команда №1 (хозяева) забила 3 гола, гости - Команда №2 забила 1 гол.
Соответственно, Команда №1 получила 3 очка, Команда №2 - 0 очков.

было принято считать, что очки гостевой команде начисляются по тому же принципу, что и у домашней, так как гостевая команда получила 0 очков за поражение (то есть столько же, сколько получила бы домашняя за поражение).

Невалидные данные (такие как `3:a`, `3- 12`) реализация игнорирует, так как они являются небезопасными и их обработка может привести к неправильному подсчету очков.