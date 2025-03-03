# OnlineShop

Тема данного приложения: "Автоматизированная информационная система для управления базой данных онлайн магазина". Стек технологий: С#, Windows Forms, Microsoft SQL Server, SqlClient. Запросы писались вручную без использования ORM.

Здесь приведено краткое руководство пользователя, подробности см. в файле "Пояснительная_записка_к_курсовой_работе.docx".


При запуске программы перед пользователем предстанет окно авторизации. Авторизация необходима для избежания несанкционированного доступа к данным пользователей нашего онлайн-магазина. 

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/dda73283-da58-41b6-83e9-ddcd25e37a19)

Если данные введены неверно:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/0861ec2d-ef39-4f4b-a667-74215b06022b)

Если данные введены верно:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/ae97d08f-0361-47bc-bd03-2b2548d2636e)

В этом же окне имеется гиперссылка на окно для создания нового пользователя АИС. 

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/64c88fe8-2813-496f-932c-b6fa276c01bb)

После успешного входа нас встречает основное окно для работы с данными:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/08edc7c8-fff0-4c6d-a182-76e80811ffae)

С помощью вкладок можно осуществлять переход между таблицами. В каждой вкладке будет таблица с данными и возможные действия с этой таблицей (добавление, удаление, изменение обновление и поиск) 

Рассмотрим всевозможные действия с таблицей пользователей онлайн-магазина.
Для удаления необходимой строки нужно нажать на нее:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/9d8e17f0-af49-4924-9ea0-721642227948)

Таким образом наши текстовые поля нового окна заполнятся автоматически. Далее нажимаем кнопку “Delete”.

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/6a4bdadc-c984-4e8c-956c-d73facbe70e8)

Для добавления новой строки нам необходимо нажать кнопку “Alter”. 

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/d7f3f106-4c2b-4f0a-aa69-56206cd1c7f6)

Как вы можете заметить, это окно идентично окну для удаления. Нажатием кнопки “Alter” можно, вручную заполнив, удалить интересующего пользователя с нашей базы данных. Однако это неудобно, поэтому рекомендуется удалять и изменять (изменение данных см. ниже) данные кликом по соответствующей строки.

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/91759874-03cb-4c62-9d4b-b5c9d9974daf)

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/89bedf56-546f-422f-9a3d-afe6dcdffc3c)

Обратите внимание, что при создании пользователя текстовое поле ID не заполняется, т.к. это автоматический счетчик для избежания повторов этого поля. Если вы проигнорируете это требование, появится следующая ошибка:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/d9e6dee6-ab3e-4b23-bcbc-c70f17616a62)

Для изменения данных пользователя нужно, как и при удалении, нажать на интересующую вас строку, а затем изменить все необходимые поля КРОМЕ поля ID, т.к. сверка командой WHERE в запросе к базе данных идет именно по ней. Это условие касается всех таблиц.

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/b3aa09b9-3b67-4a54-b4a6-fab10234a00a)

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/382b7c59-8ef0-4ccf-969e-45d9fd941f15)

Рассмотрим поиск по таблице. Сначала нам нужно выбрать поле, по которому мы хотим фильтровать информацию. Для этого выбираем нужную строку в comboBox:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/8d295a09-7019-497a-b551-f85ecdb19a55)

Затем заполняем textBox информацией для поиска и нажимаем на кнопку “Search”:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/295882be-a7c0-4ec2-8cbc-ec4fa28d75e4)

Результат:
![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/8cc1d969-8714-4e00-94c1-b8347d01efa3)

Рассмотрим некоторые нюансы для таблицы Purchase, а именно работу с объектами DateTimePicker:
В DateTimePicker сначала выберем дату:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/cb2253f6-3154-4c40-b873-dbe9f137c03f)

А затем прописываем время покупки товара пользователем:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/18e13caa-3002-4c22-9d45-7230b02cc581)

Вкупе получаем следующее:

![image](https://github.com/FanisNgv/OnlineShop/assets/86799209/0cadd5de-8e67-48fa-9dbe-29362634f46c)
