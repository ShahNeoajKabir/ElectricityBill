import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  // {
  //   title: true,
  //   name: 'Theme'
  // },
  {
    name: 'User',
    url: '/User/View',
    icon: 'icon-user'
  },
  {
    name: 'Role',
    url: '/Role/View',
    icon: 'icon-book-open'
  },
  {
    name: 'User Role',
    url: '/UserRole/View',
    icon: 'icon-people'
  },
  {
    name: 'Meter',
    url: '/Meter/View',
    icon: 'icon-speedometer'
  },
  {
    name: 'Zone',
    url: '/Zone/View',
    icon: 'icon-location-pin'
  },
  {
    name: 'ZoneAssign',
    url: '/ZoneAssign/View',
    icon: 'icon-location-pin'
  },
  {
    name: 'Customer',
    url: '/Customer/View',
    icon: 'icon-user'
  },
  {
    name: 'Pending Customer',
    url: '/Customer/PendingCustomer',
    icon: 'icon-user'
  },

  {
    name: 'Billl',
    url: '/Bill/View',
    icon: 'icon-user'
  },
  {
    name: 'PaymentHistory',
    url: '/Bill/PaimentHistory',
    icon: 'icon-user'
  },

  
  {
    name: 'Card',
    url: '/Card/View',
    icon: 'icon-user'
  },
  {
    name: 'MobileBanking',
    url: '/MobileBanking/View',
    icon: 'icon-user'
  },
  
  {
    name: 'Assign Meter',
    url: '/AssignMeter/View',
    icon: 'icon-list'
  },
  {
    name: 'Unit Price',
    url: '/UnitPrice/View',
    icon: 'icon-list'
  },
  {
    name: 'MeterReading',
    url: '/MeterReading/View',
    icon: 'icon-speedometer'
  },

];
export const navItemsCoOrdinators: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Meter',
    url: '/Meter/View',
    icon: 'icon-speedometer'
  },
  {
    name: 'Pending Customer',
    url: '/Customer/PendingCustomer',
    icon: 'icon-user'
  },

  {
    name: 'Assign Meter',
    url: '/AssignMeter/View',
    icon: 'icon-list'
  },
  {
    name: 'Unit Price',
    url: '/UnitPrice/View',
    icon: 'icon-list'
  },


];

export const navItemsMeterReader: INavData[] = [
 
  // {
  //   title: true,
  //   name: 'Theme'
  // },

  
 
 
  {
    name: 'Customer Meter',
    url: '/AssignMeter/CustomerMeter',
    icon: 'icon-list'
  },
  
  
  {
    name: 'MeterReading',
    url: '/MeterReading/View',
    icon: 'icon-speedometer'
  },

];

