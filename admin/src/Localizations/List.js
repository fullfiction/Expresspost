import React from "react";
import { useMediaQuery } from "@material-ui/core";
import UnixDateField from "../Components/UnixDateField"
import {
	List,
	SimpleList,
	Datagrid,
    TextField,
    DateField
} from "react-admin";

const LocalizationsList = props => (
    <List {...props}>
        <Datagrid rowClick="edit">
            <UnixDateField source="created" />
            <TextField source="key" />
            <TextField source="context" />
            <TextField source="locale" />
            <TextField source="value" />
        </Datagrid>
    </List>
);

export default LocalizationsList;