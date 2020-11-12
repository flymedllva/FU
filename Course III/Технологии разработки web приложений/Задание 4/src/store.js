import {writable} from 'svelte/store';

let initData = [
    {
        "id": getRandomInt(1000000, 99999999),
        "name": "Дима",
        "exam_score": 40,
        "sem_score": 9,
        "discipline": "WEB"
    },
    {
        "id": getRandomInt(1000000, 99999999),
        "name": "Иван",
        "exam_score": 59,
        "sem_score": 22,
        "discipline": "Машинное обучение"
    }
]

let storageName = "dict"

function setLocalStorage(data) {
    localStorage.setItem(storageName, JSON.stringify(data));
    return data
}

function checkId(data, id) {
    return data.filter((o) => o.id === id).length > 0;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
}

function storeCreate() {
    let data = JSON.parse(localStorage.getItem(storageName))
    if (data === null)
        data = setLocalStorage(initData)

    const {subscribe, update} = writable(data);

    return {
        subscribe,
        add: (user) => update(function (state) {
            if (state.length > 0) {
                let newID = getRandomInt(1000000, 99999999)
                while (checkId(data, newID))
                    newID++
                user.id = newID
            } else {
                user.id = getRandomInt(1000000, 99999999)
            }
            return setLocalStorage([...state, user])
        }),
        edit: (idx, user) => update(function (state) {
            state[idx] = user
            return setLocalStorage(state)
        }),
        delete: (idx) => update(function (state) {
            return setLocalStorage([...state.slice(0, idx), ...state.slice(idx + 1)]);
        }),
        clear: () => update(() => setLocalStorage([]))
    }
}

export const store = storeCreate();
