# FirebaseApp.FirebaseSender

Модуль отправки push-уведомлений на сервер Firebase.

Получает команды на немедленную отправку сообщений (по http или из очереди сообщений), 
на уровне бизнес-логики подготавливает и отправляет данные. Сообщает вызывающему сервису об успехе или ошибке отправки.

Кроме того, постоянно проверяет в БД Redis наличие сообщений, для которых подошло время отправки. Отправляет эти сообщения и уведомляет об успехе или ошибке InternalAPI,
который должен будет записать данные об этом в БД Ms SQL.
