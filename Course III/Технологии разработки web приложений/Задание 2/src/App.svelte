<script>
    import { quintOut } from 'svelte/easing';
    import { crossfade } from 'svelte/transition';
    import { flip } from 'svelte/animate';

    let cells = [{"id": 1, "value": "Тест K"}, {"id": 2, "value": "Тест Z"}, {"id": 3, "value": "Тест Q"}, {"id": 4, "value": "Тест D"}]

    let selectedCellColor = "#FF0000"
    let selectedCellID = ""
    
    const [send, receive] = crossfade({
        duration: d => Math.sqrt(d * 200),

        fallback(node, params) {
            const style = getComputedStyle(node);
            const transform = style.transform === 'none' ? '' : style.transform;

            return {
                duration: 600,
                easing: quintOut,
                css: t => `
					transform: ${transform} scale(${t});
					opacity: ${t}
				`
            };
        }
    });

</script>

<div class="container">
    <div class="item">
        <div class="task-title">
            <h1>Task 2</h1>
            <h4>ПИ18-1, Вариант 8</h4>
            <h4>Гриднев Дмитрий Владимирович</h4>
            <p>В HTML-документе определены 2 формы.
                На первой управляющие кнопки и поля ввода, вторая  - пустая.
                При нажатии на кнопки первой формы на второй форме генерируются элементы (а).
                Параметры и количество элементов определяются в элементах 1-й формы(б),
                а также заданы в виде массивов на JavaScript.
                После построения элементов на второй форме по некоторым кнопкам/элементам
                можно произвести некоторые действия (в), результаты которых отображаются на 2-форме.
                Для генерации элементов и вывода результатов использовать свойство innerHTML.
                Примечание. Уточнения постановки производить самостоятельно.
            </p>
            <ul>
                <li>(а) TABLE из одного столбца, ссылки в ячейках таблицы</li>
                <li>(б)В элементе INPUT выбрать цвет, указав номер ячейки.</li>
                <li>(в)Определить число ссыкок в документе HTML</li>
                <li>Значения ссылок заданы в массиве</li>
            </ul>
        </div>
    </div>
    <div class="item">
        <h1>Form 1</h1>
        <label>
            <input type="color" bind:value={selectedCellColor}>
            <input bind:value={selectedCellID} placeholder="Выберите ячейку " list="cellsID">
            <datalist id="cellsID">
                {#each cells as cell (cell.id)}
                    <option>{cell.id}</option>
                {/each}
            </datalist>
        </label>
        <p>Количество ссылок: {cells.length}</p>
        <h1>Form 2</h1>
        <table>
            {#each cells as cell (cell.id)}
                <tr in:receive="{{key: cell.id}}"
                    out:send="{{key: cell.id}}"
                    animate:flip>
                    <th>{cell.id}</th>
                    <th style="background-color: {cell.id.toString() === selectedCellID ? selectedCellColor : ''}">
                        {cell.value}
                    </th>
                </tr>
            {/each}
        </table>
    </div>
</div>


<style>
    table {
        width: 100%;
        border-collapse: collapse;
        border: 3px solid #000000;
    }
    th {
        transition: background-color 300ms linear;
    }

    :global(body) {
        margin: 0;
    }

    .container {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        background-color: #eee;
        height: 100vh;
    }

    .item {
        width: 500px;
        margin: 5px;
        background-color: white;
        padding: 20px;
        border-radius: 25px;
        box-shadow: 0 0 4px rgba(0, 0, 0, 0.25);
    }

    .task-title h1 {
        margin-top: 0;
        margin-bottom: 8px;
    }

    .task-title h4 {
        margin-top: 0;
        margin-bottom: 4px;
    }

</style>
