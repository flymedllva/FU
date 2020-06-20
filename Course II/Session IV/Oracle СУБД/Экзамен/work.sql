CREATE OR REPLACE PROCEDURE FULL_NAME_SALARY(c_last_name VARCHAR2) IS v_employees EMPLOYEES%ROWTYPE;
BEGIN
    SELECT *
    INTO v_employees
    FROM EMPLOYEES
    WHERE LAST_NAME = c_last_name;
    dbms_output.put_line(v_employees.FIRST_NAME || ' ' || v_employees.LAST_NAME || ' ' || v_employees.SALARY);
EXCEPTION
    WHEN TOO_MANY_ROWS THEN
        dbms_output.put_line( 'Найдено больше 1 сотрудника с фамилией ' || c_last_name);
    WHEN OTHERS THEN
        dbms_output.put_line( 'Сотрудник ' || c_last_name || ' ' || 'Не найден');
END FULL_NAME_SALARY;

BEGIN
    FULL_NAME_SALARY('Kochhar');
    FULL_NAME_SALARY('Abel');
    FULL_NAME_SALARY('Test');
END;

