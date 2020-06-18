import React from "react";
import { useMediaQuery } from "@material-ui/core";
import {
	List,
	SimpleList,
	BooleanInput,
	Datagrid,
	TextField,
	BooleanField,
	EmailField,
	DateField,
	Edit,
	SimpleForm,
	ReferenceInput,
	ReferenceField,
	TextInput,
	SelectInput,
	DateInput,
	Create,
	Filter,
	required,
	SingleFieldList,
	ChipField,
	ReferenceManyField,
    EditButton,
    NullableBooleanInput,
} from "react-admin";

const BranchesFilter = (props) => (
	<Filter {...props}>
        <NullableBooleanInput label="Stores" source="isStore" alwaysOn />
		<TextInput label="Address line 1" source="addressLine1" />
		<TextInput label="Address line 2" source="addressLine2" />
		<TextInput label="State" source="state" />
		<TextInput label="Email" source="email" />
		<TextInput label="Zip Code" source="zipCode" />
        <ReferenceInput source="countryId" reference="Countries"><SelectInput optionText="name" /></ReferenceInput>
        <ReferenceInput source="companyId" reference="Companies"><SelectInput optionText="name" /></ReferenceInput>
	</Filter>
);

export const BranchList = props => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<BranchesFilter />} {...props}>
			{isSmall ? (
                <SimpleList primaryText={(record) => record.addressLine1} 
                            secondaryText={(record) => record.addressLine2 }/>
			) : (
                <Datagrid rowClick="edit">
                    <BooleanField source="isStore" />
                    <TextField source="addressLine1" />
                    <TextField source="addressLine2" />
                    <TextField source="state" />
                    <EmailField source="email" />
                    <TextField source="phonenumber" />
                    <TextField source="zipCode" />
                    <ReferenceField source="countryId" reference="Countries"><TextField source="name" /></ReferenceField>
                    <ReferenceField source="companyId" reference="Companies"><TextField source="name" /></ReferenceField>
                </Datagrid>
			)}
		</List>
	);
};

export const BranchEdit = props => (
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

export const BranchCreate = props => (
    <Create {...props}>
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
    </Create>
);