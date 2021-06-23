const fs = require('fs');
const express = require('express') // Сервер
const cors = require('cors') // CORS браузера
const morgan = require('morgan') // Логгер
const xml2js = require('xml2js');
const parseString = require('xml2js').parseString;

const PORT = 8000
const XML_FILE_NAME = "items.xml"

let app = express();

app.use(morgan('combined'))
app.use(cors())
app.use(express.json());

let items = []
const xml = fs.readFileSync(XML_FILE_NAME, 'utf8');
parseString(xml, function (err, result) {
    for (let i = 0; i < result.root.id.length; i++) {
        let item = {
            "id": result.root.id[i],
            "surname": result.root.surname[i],
            "academicTitle": result.root.academicTitle[i],
            "workExperience":  Number(result.root.workExperience[i])
        }
        items = [...items, item]
    }
});

// Сохраняет данные в файл
function saveItems(items) {
    const builder = new xml2js.Builder();
    const xml = builder.buildObject(items);
    fs.writeFile(XML_FILE_NAME, xml, 'utf8', () => undefined);
}

// Генерирует случайные числа в диапазоне
function randomInteger(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Получение преподавателей
app.get('/teachers', (req, res) => {
    res.json(items)
})

// Создание пользователя
app.post('/teacher', function (req, resp) {
    // Проверка что данные не битые
    if (req.body && req.body.surname && req.body.academicTitle && req.body.workExperience) {
        const item = req.body
        let newItem = {
            "id": randomInteger(99999, 9999999999999),
            "surname": item.surname,
            "academicTitle": item.academicTitle,
            "workExperience": item.workExperience
        }
        items = [...items, newItem]
        saveItems(items)
        resp.send(newItem);
    } else {
        resp.status(400)
    }
});

// Запуск сервера
app.listen(PORT, () => {
    console.log(`⚡️[server]: Server is running at http://localhost:${PORT}`);
})