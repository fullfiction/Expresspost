import React from "react";
import {
	BooleanInput,
	Edit,
	SimpleForm,
	ReferenceInput,
	TextInput,
	SelectInput
} from "react-admin";


const BranchEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <BooleanInput source="isStore" />
            <TextInput source="addressLine1" />
            <TextInput source="addressLine2" />
            <TextInput source="state" />
            <TextInput source="email" />
            <TextInput source="phonenumber" />
            <TextInput source="zipCode" />
            <ReferenceInput source="countryId" reference="Countries"><SelectInput optionText="name" /></ReferenceInput>
            <ReferenceInput source="companyId" reference="Companies"><SelectInput optionText="name" /></ReferenceInput>
        </SimpleForm>
    </Edit>
);

export default BranchEdit;