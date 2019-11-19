## Реализовано
- Реализовано конкурентное судоку: несколько игроков одновременно параллельно заполняет судоку
- Запрос имени
- Вывод ходов игроков
- Вывод топ-игроков
- Отслеживается выигрыш и проигрыш(в одну из клеток нельзя поставить ни одной из цифр)
- Общение с сервером через WebSocket.
- Freelock хранилище

Технологический стек:
- Серверная часть выполнена на Asp.Net Core 3. 
- Для работы с WebSockets используется SignalR.
- Frontend реализован на React+Typescript.


## ТЗ

Написать Игру судоку с конкурентной борьбой.

Должен быть реализован бэкэнд с WebSockets с методами: начало новой игры,
добавить результат, топ игроков (хранить результаты можно в кэше сервера).
Должен быть простой фронт с полями под игру, полем для имени, кнопками
начать и просмотр топ.

Логика:
- Несколько вкладок играют в конкурентное судоку, то есть одна текущая игра на всех.
- Каждый имеет право поставить в свободную ячейку.
- Кто первый поставит последнюю цифру и судоку посчитается правильно, тот и победил.
- Любая цифра, поставленная на поле, должна отобразиться у других без
возможности изменения.