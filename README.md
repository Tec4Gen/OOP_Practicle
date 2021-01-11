# Инструкция по запуску
Для того, чтобы запустить проект сайта с монетами, вам потребуется visual studio и Microsoft SQL Server Management Studio.

В папке с проектом лежат скрипты, для создания базы данных (папка DataBaseScripts).
Нужно запустить файл DataBase.sql и нажать кнопку на панели инструментов “Выполнить”, у нас будет создана база данных «Coins». Далее нам нужно создать роли на сайте, 
для этого нужно в базе данных, во вкладке «Таблицы» правой кнопкой мыши нажать на «dbo.RoleWebSite» и в столбце «Name» написать роли. 
Можно, прописать одну либо две, на усмотрение пользователя. Роль под id 1 – User, роль под id 2 – Admin (при регистрации пользователя по умолчанию будет дана роль User с ограниченными возможностями, 
но в базе данных можно поменять роль появившегося зарегистрированного пользователя на Admin).

Далее нужно подключить базу данных к проекту.

1. Откройте проект приложения запустив .sln

2. Чтобы открыть окно Источники данных , в меню вид выберите другие > Источники данных Windows.

3. В окне Источники данных выберите Добавить новый источник данных.

Откроется Мастер настройки источника данных .

4. На странице Выбор типа источника данных выберите база данных , а затем нажмите кнопку Далее.

5. На странице Выбор модели базы данных выберите набор данных , а затем нажмите кнопку Далее.

6. На странице Выбор подключения базы данных выберите Новое подключение для настройки нового подключения к данным. Откроется диалоговое окно Добавление соединения.

7. Если источник данных не установлен в файл базы данных Microsoft Access , нажмите кнопку изменить .

8. Откроется диалоговое окно изменение источника данных . В списке источников данных выберите файл базы данных Microsoft Access. В раскрывающемся списке поставщик данных выберите .NET Framework поставщик данных для OLE DB и нажмите кнопку ОК.

9. Нажмите кнопку Обзор рядом с именем файла базы данных , а затем перейдите к файлу ACCDB и нажмите кнопку Открыть.

10. Введите имя пользователя и пароль (при необходимости) и нажмите кнопку ОК.

11. На странице Выбор подключения к данным нажмите кнопку Далее .

Возможно, появится диалоговое окно с сообщением о том, что файл данных отсутствует в текущем проекте. Выберите Да или нет.

12. Нажмите кнопку Далее в строке сохранить подключение на странице файл конфигурации приложения.

1. Назначаем «WebPL» автозагружаемым проектом.

2. Далее заходим в «Обозреватель серверов» - нажимаем правую кнопку мыши – «Свойства» на нужной базе данных – копируем строку подключения – вставляем в «Web.config»

<connectionStrings>

<add name="Coins" connectionString="Data Source=DESKTOP-8KVUVDE\SQLEXPRESS;Initial Catalog=Coins;Integrated Security=True"/>

</connectionStrings>

Где connectionString равен вашей строке подключения (которую мы скопировали).

Далее запускаем проект.

1. Можно просматривать альбомы с монетами и статьи в разделе обучения.

2. Можно регистрироваться под своим именем.

3. При желании сделать себя админом, как было сказано выше. В этой роли у вас появится возможность добавлять монеты на сайт.
