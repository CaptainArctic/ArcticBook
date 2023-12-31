http://arcticmanga.somee.com/

#  Проект «ArcticBook»

## Описание проекта

Проект ArcticBook – Сервис с переводами манги на русский язык. С помощью этого сервиса пользователи смогут просматривать различные произведения японской культуры.

**Что могут делать пользователи:**
- Просматривать страницы манги.
- Использовать поиск по названию для быстрого нахождения необходимого тайтла.

**Что может делать администратор:**
Администратор обладает всеми правами авторизованного пользователя. Плюс к этому он может:

- Добавлять, удалять, редактировать жанры.
- Добавлять, удалять, редактировать литературные произведения.
- Добавлять, удалять страницы манги.

## Инструкция по установке

Склонируйте репозиторий на свой компьютер
```
git clone git@github.com:CaptainArctic/ArcticBook.git
```

## Запуск проекта локально

Сборка и развертывание контейнеров:
```
docker-compose up -d --build
```
Миграции и статика выполняются автоматически.
Далее необходимо создать суперпользователя:
```
docker-compose exec backend python manage.py createsuperuser
```
Наполните БД ингредиентами:
```
docker-compose exec backend python manage.py load_ingredients
```
- Вход на сайт по адресу: http://localhost/
- Админ панель: http://localhost/admin/
- Документация: http://localhost/api/docs/


## Развёртывание на сервер

Подключитесь к удаленному серверу
```
ssh -i PATH_TO_SSH_KEY/SSH_KEY_NAME USERNAME@SERVER_IP_ADDRESS 
```
Создайте на сервере директорию foodgram
```
mkdir foodgram
```
Установите Docker Compose на сервер
```
sudo apt update
sudo apt install curl
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh
sudo apt install docker-compose
```
Скопируйте файлы docker-compose.yml и .env в директорию foodgram/ на сервере
```
scp -i PATH_TO_SSH_KEY/SSH_KEY_NAME docker-compose.yml
USERNAME@SERVER_IP_ADDRESS:/home/USERNAME/foodgram/docker-compose.yml
```
Запустите Docker Compose в режиме демона
```
sudo docker-compose -f /home/USERNAME/foodgram/docker-compose.yml up -d
```
Выполните миграции, соберите статические файлы бэкенда и скопируйте их в backend_static/static/
```
sudo docker-compose -f /home/USERNAME/foodgram/docker-compose.yml exec backend python manage.py migrate
sudo docker-compose -f /home/USERNAME/foodgram/docker-compose.yml exec backend python manage.py collectstatic
sudo docker-compose -f /home/USERNAME/foodgram/docker-compose.yml exec backend cp -r /app/collected_static/. /backend_static/static/
```

Откройте конфигурационный файл Nginx в редакторе nano
```
sudo nano /etc/nginx/sites-enabled/default
```
И измените настройки location в разделе 'server'
```
location / {
    proxy_set_header Host $http_host;
    proxy_pass http://127.0.0.1:8000;
}
```
Проверьте правильность конфигурации Nginx
```
sudo nginx -t
```
Перезапустите Nginx
```
sudo service nginx reload
```
## Технологии
- Python 3.11.1
- Django 3.2.3
- PostgreSQL 13.10
- gunicorn 20.1.0

## Автор
Павлов Кирилл (https://github.com/CaptainArctic)

Проект доступен по адресу: http://arcticmanga.somee.com/
