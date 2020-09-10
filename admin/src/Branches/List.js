import React from "react";
import { useMediaQuery } from "@material-ui/core";
import UnixDateField from "../Components/UnixDateField"
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	BooleanField,
	EmailField,
	ReferenceInput,
	ReferenceField,
	TextInput,
	SelectInput,
	Filter,
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

const BranchesList = props => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<BranchesFilter />} {...props}>
			{isSmall ? (
                <SimpleList primaryText={(record) => record.addressLine1} 
                            secondaryText={(record) => record.addressLine2 }/>
			) : (
                <Datagrid rowClick="edit">
					<UnixDateField source="created" />
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

export default BranchesList;