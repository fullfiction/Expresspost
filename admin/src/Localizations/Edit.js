import LocalizationsList from "./List";
import React from 'react'
import {
    Edit,
    SimpleForm,
    NumberInput,
    TextInput,
    required
} from 'react-admin'
import UnixDateField from "../Components/UnixDateField";


const LocalizationEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <NumberInput source="id" disabled/>
            <UnixDateField source="created" />
            <TextInput source="key" />
            <TextInput source="context" />
            <TextInput source="locale" />
            <TextInput source="value" />
        </SimpleForm>
    </Edit>
);

export default LocalizationEdit;