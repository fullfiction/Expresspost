import React from "react";
import moment from "moment"
import {DateField} from "react-admin"

const UnixDateField = props => {
    var dateString = moment.unix(props.record[props.source]).format("MM/DD/YYYY");
    props.record[props.source] = dateString;
    return <DateField {...props} />
}

export default UnixDateField;