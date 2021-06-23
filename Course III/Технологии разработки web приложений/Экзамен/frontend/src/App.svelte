<script>
    // ПИ18-1 Гриднев Д.В.
    import {onMount} from 'svelte';
    import {
        Content,
        Breadcrumb,
        BreadcrumbItem,
        Grid,
        Row,
        Column,
        DataTableSkeleton,
        ToastNotification,
        DataTable,
        Button,
        ButtonSet,
        NumberInput,
        TextInput,
        Tile,
    } from "carbon-components-svelte";
    import Header from "./components/Header.svelte";

    // consts
    const host = "http://localhost:8000"

    // vars
    let columnItems = [];
    let loadError;
    let formError;
    let selectedRowIds = [];

    // Загрузка при старте страницы
    onMount(async () => {
        await new Promise(r => setTimeout(r, 800))
        await loadItems()
    });

    // Загружает элементы
    async function loadItems() {
        const response = await fetch(host + "/teachers")
            .then(response => response.json().then(data => ({
                data: data,
                status: response.status
            })))
            .catch(error => {
                loadError = error
            })
            .then(res => {
                if (res.status === 200) {
                    columnItems = res.data
                }
            })
    }

    let formSurname
    let formAcademicTitle
    let formWorkExperience = 0
    let selectedItem = undefined

    async function addTeacher() {
        const response = await fetch(host + "/teacher", {
            method: 'post',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "surname": formSurname,
                "academicTitle": formAcademicTitle,
                "workExperience": formWorkExperience,
            })
        }).then(response => response.json().then(data => ({
            data: data,
            status: response.status
        })))
            .catch(error => {
                formError = error
                console.log(error)
            })
            .then(res => {
                console.log(res)
                if (res.status === 200) {
                    columnItems = [...columnItems, res.data]
                    formError = undefined
                }
                clearForm()
            })
    }

    async function clearForm() {
        formWorkExperience = 0
        formSurname = ""
        formAcademicTitle = ""
    }

    function sleep(ms) {
        return (new Promise(function (resolve, reject) {
            setTimeout(function () {
                resolve();
            }, ms);
        }));
    }

    let foundTeacher

    async function finder(cmp, arr, attr) {
        let val = arr[0][attr];
        for(let i=1; i<arr.length; i++) {
            val = cmp(val, arr[i][attr])
        }
        return val;
    }

    async function foundMinTeacher() {
        let min = 9999999999
        let fItem
        columnItems.forEach(item => {
            if (item.workExperience < min) {
                min = item.workExperience
                fItem = item
            }
        })
        foundTeacher = fItem
    }

    async function clearCountingForm() {
        foundTeacher = undefined
    }

    $: if (selectedRowIds) {
        if (selectedRowIds.length > 0) {
            const selectedRowId = selectedRowIds[0]
            columnItems.forEach(item => {
                if (item.id === selectedRowId) {
                    selectedItem = item
                    formWorkExperience = selectedItem.workExperience
                    formAcademicTitle = selectedItem.academicTitle
                    sleep(500).then(function () {
                        selectedRowIds = []
                    });
                }
            })
        }
    }
</script>

<Header/>
<Content style="background: none; padding: 1rem">
    <Grid>
        <Row>
            <Column lg="{16}">
                <Breadcrumb noTrailingSlash aria-label="Page navigation">
                    <BreadcrumbItem href="/">web-приложение</BreadcrumbItem>
                </Breadcrumb>
                <h1 style="margin-bottom: 1.5rem">Список преподавателей</h1>
            </Column>
        </Row>
        <Row>
            <Column>
                <Tile>
                    <p>
                        Главная форма web-приложения содержит список преподавателей (фамилия, *) в виде **. Первый
                        элемент данных – ключевое поле. По кнопке «Добавить» данные заданной строки кроме первых трех
                        полей переносятся на форму для редактирования данных с полями соответствующего вида. Фамилия
                        вводится в поле ввода. По кнопке «Записать» измененные данные добавляются в общий список. По
                        кнопке «Определить» выводится преподаватель ***. Исходные данные таблицы заданы в массиве (20
                        баллов)
                        *ученое звание, стаж
                        **таблицы
                        ***с минимальным стажем
                    </p>
                    <br>
                    <p>
                        Изменить приложение, чтобы исходные данные выбирались с сервера в формате XML без атрибутов, а
                        также туда же сохранялись изменения (10 баллов)
                    </p>
                </Tile>
            </Column>
        </Row>
        <br>
        <Row>
            <Column>
                {#if columnItems.length > 0}
                    <DataTable
                            zebra
                            radio
                            sortable
                            bind:selectedRowIds
                            title="Список преподавателей"
                            description="При выборе преподавателя, его данные будут скопированы в форму создания нового преподавателя."
                            headers={[{ key: 'surname', value: 'Фамилия' }, {key: 'academicTitle', value: 'Ученое звание'}, { key: 'workExperience', value: 'Стаж' }]}
                            rows={columnItems}
                    >
                    </DataTable>
                {:else}
                    {#if !loadError}
                        <DataTableSkeleton headers={['Фамилия', 'Ученое звание', 'Стаж']} rows={4}
                                           style="height: 70vh; width: 100%;"/>
                    {:else}
                        <ToastNotification
                                title="Ошибка"
                                subtitle="Не удалось подключиться к серверу, возможно он не работает."
                                caption={new Date().toLocaleString()}
                        />
                    {/if}
                {/if}
            </Column>
            <Column>
                <h4>Создание преподавателя</h4>
                <hr>
                <br>
                <TextInput
                        labelText="Фамилия преподавателя"
                        helperText="Введите корректную фамилию"
                        placeholder="Введите фамилию преподавателя..."
                        bind:value={formSurname}
                />
                <br>
                <TextInput
                        labelText="Ученое звание"
                        helperText="Введите ученое звание"
                        placeholder="Введите ученое звание преподавателя..."
                        bind:value={formAcademicTitle}
                />
                <br>
                <NumberInput
                        min={0}
                        max={100}
                        invalidText="Неправильные данные"
                        helperText="Введите стаж преподавателя"
                        label="Стаж (0 мин, 100 макс)"
                        bind:value={formWorkExperience}
                />
                <br>
                <ButtonSet>
                    <Button on:click={addTeacher}>Добавить преподавателя</Button>
                    <Button kind="secondary" on:click={clearForm}>Очистить форму</Button>
                </ButtonSet>
                {#if formError}
                    <ToastNotification
                            title="Ошибка добавления преподавателя"
                            subtitle="Не удалось подключиться к серверу, возможно он не работает. Попробуйте еще раз."
                            caption={new Date().toLocaleString()}
                    />
                {/if}
            </Column>
            <Column>
                <h4>Преподаватель с минимальным стажем</h4>
                <hr>
                <br>
                {#if foundTeacher}
                    <h5>Найденный преподаватель</h5>
                    <br>
                    <p>
                        Фамилия: {foundTeacher.surname}
                    </p>
                    <p>
                        Ученое звание: {foundTeacher.academicTitle}
                    </p>
                    <p>
                        Стаж: {foundTeacher.workExperience}
                    </p>
                {/if}
                <br>
                <ButtonSet>
                    <Button on:click={foundMinTeacher}>Определить преподавателя с минимальным стажем</Button>
                    <Button kind="secondary" on:click={clearCountingForm}>Очистить</Button>
                </ButtonSet>
            </Column>
        </Row>
    </Grid>
</Content>
