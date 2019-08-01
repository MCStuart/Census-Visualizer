import React, { Select, useState } from 'react';

const options = [
    { value: '1', label: 'Alabama' },
    { value: '2', label: 'Alaska' },
    { value: '3', label: 'Arizona' },
    { value: '4', label: 'Arkansas' },
    { value: '5', label: 'California' },
    { value: '6', label: 'Colorado' },
    { value: '7', label: 'Connecticut' },
    { value: '8', label: 'Delaware' },
    { value: '9', label: 'Florida' },
    { value: '10', label: 'Georgia' },
    { value: '11', label: 'Hawaii' },
    { value: '12', label: 'Idaho' },
    { value: '13', label: 'Illinois' },
    { value: '14', label: 'Indiana' },
    { value: '15', label: 'Iowa' },
    { value: '16', label: 'Kansas' },
    { value: '17', label: 'Kentucky' },
    { value: '18', label: 'Louisiana' },
    { value: '19', label: 'Maine' },
    { value: '20', label: 'Maryland' },
    { value: '21', label: 'Massachusetts' },
    { value: '22', label: 'Michigan' },
    { value: '23', label: 'Minnesota' },
    { value: '24', label: 'Mississippi' },
    { value: '25', label: 'Missouri' },
    { value: '26', label: 'Montana' },
    { value: '27', label: 'Nebraska' },
    { value: '28', label: 'Nevada' },
    { value: '29', label: 'New Hampshire'  },
    { value: '30', label: 'New Jersey'  },
    { value: '31', label: 'New Mexico'  },
    { value: '32', label: 'New York'  },
    { value: '33', label: 'North Carolina'  },
    { value: '34', label: 'North Dakota'  },
    { value: '35', label: 'Ohio' },
    { value: '36', label: 'Oklahoma' },
    { value: '37', label: 'Oregon' },
    { value: '38', label: 'Pennsylvania' },
    { value: '39', label: 'Rhode Island'  },
    { value: '40', label: 'South Carolina'  },
    { value: '41', label: 'South Dakota'  },
    { value: '42', label: 'Tennessee' },
    { value: '43', label: 'Texas' },
    { value: '44', label: 'Utah' },
    { value: '45', label: 'Vermont' },
    { value: '46', label: 'Virginia' },
    { value: '47', label: 'Washington' },
    { value: '48', label: 'West Virginia'  },
    { value: '49', label: 'Wisconsin' },
    { value: '50', label: 'Wyoming' },
  ];

export default function SelectedDropdown() {
  const [selectedOption, setSelectedStateId] = useState('');
  
  const handleChange = (selectedOption) => {
    setSelectedStateId(selectedOption.value);

    console.log(`Option selected:`, selectedOption);
  };

  return (
    <div>
      <SelectedDropdown value={selectedOption} onChange={handleChange} options={options} />
    </div>
  );
}